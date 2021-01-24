    public IEnumerable<string> ParseCsv(string file, out IEnumerable<string> records)
    {
        var results = new List<string>();
        records = results;
        //... (actual parsing)
        results.Add("foo");
        results.Add("bar");
        return Enumerable.Empty<string>(); //Returning errors
    }
