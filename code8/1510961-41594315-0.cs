    using (var db = new MyDatabase())
    {
        var substrings = new List<string> { "ello", "re" };
        var result = db.MyTable.Where(i => substrings.Any(l => i.Value.Contains(l))).ToList();
    }
