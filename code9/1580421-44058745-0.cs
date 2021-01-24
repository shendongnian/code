    public IQueryable<RuleLoadCollection_Result> GetRuleLibraryFromCache()
        {
            var result = _cache.Get<IEnumerable<RuleLoadCollection_Result>>("TestKey").AsQueryable();
            return result;
        }
