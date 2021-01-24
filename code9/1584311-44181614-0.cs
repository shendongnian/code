    [HttpGet]
    public MyTable GetMyTable(byte id, string langId)
    {
        List<MyTable> results = new List<MyTable>();
        if (id == 0)
        {
            results = db.MyTables.Where(x => x.LanguageId == langid).ToList();
        }
        else
        {
            var find = db.MyTables.Find(id, langId);
            if (find != null) results.Add(find);
        }
        return results;
    }
