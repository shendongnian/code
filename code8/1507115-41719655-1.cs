     class FilterGroup
        {
            public string Name { get; set; }
        public IList<FilterAttribute> Attributes { get; set; }
        public static IEnumerable<FilterGroup> CreateList(ISearchResponse<SearchItem> result)
        {
            return result.Aggs.Nested("filters").Terms("groups").Buckets.Select(g => new FilterGroup()
            {
                Name = g.Key,
                Attributes = g.Terms("attributes").Buckets.Select(x => new FilterAttribute()
                    {
                        Count = (int)x.DocCount,
                        Name = x.Key
                    }).ToList()
            });           
        }
    }
    class FilterAttribute
    {
        public string Name { get; set; }
        public int Count { get; set; }
    }
