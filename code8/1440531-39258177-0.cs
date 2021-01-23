    private IEnumerable<MiaLog1A> PopulateQuery(string selectedCampus)
    {
        var list = new List<string> {"Fall","Mid","Spring"};
        return _db.MiaLog1A.Where(m => m.Campus == selectedCampus)
                .OrderBy(m => m.StudentName)
                .ThenBy(m=> list.IndexOf(m.Term))  
            .AsEnumerable();
    }
