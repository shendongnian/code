    public List<string[]> GetRec(int hid)
    {
        var list =
            (from x in table1
                join y in table2 on x.Hid equals y.Hid       
                where x.Hid == hid
                select new {x.Name, x.Description, x.User})
            .Select(a => { return new string[] { a.Name, a.Description, a.User}; }).ToList();
        return list;
    }
