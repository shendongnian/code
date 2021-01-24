    public async Task<PagedItems<UserProfileModel>> FindAsync(string searchTerm, int skip, int take)
    {
        var client = _elasticClientProvider.GetClient();
        var response = await client.SearchAsync<UserProfileModel>(s => s
            .Index(_elasticConfiguration.GetIndex())
            .Source(f => f.Includes(si => si.Field(u => u.Email)))
            .From(skip).Size(take)
            .Query(q => q.MultiMatch(m => m.Fields(f => f
                .Field(u => u.Email)
                .Field(u => u.FirstName)
                .Field(u => u.LastName))
                .Query(searchTerm)))
            .Sort(q => q.Ascending(u => u.Email.Suffix("keyword"))));
        var count = await client.CountAsync<UserProfileModel>(s => s.Index(_elasticConfiguration.GetIndex()));
        return new PagedItems<UserProfileModel> { Items = response.Documents.ToArray(), Total = count.Count };
    }
