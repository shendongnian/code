    public IEnumerable<Document1> List()
    {
        var document1Collection = Database.GetCollection<Document1>("Document1");
        var document2Collection = Database.GetCollection<Document2>("Document2");
        var document2Lookup = document2Collection.AsQueryable().ToLookup(x => x.Id);
        foreach (var document1 in document1Collection.AsQueryable())
        {
            document1.Document2 = document2Lookup[document1.Document2Id].FirstOrDefault();
            yield return document1;
        }
    }
