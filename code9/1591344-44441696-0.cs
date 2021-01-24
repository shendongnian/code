    public searchEntities(string query, list<string> columnNames)
    {
       await db.entities.SelectDynamic(x => "{" + string.Join(",", columnNames) + "}")
    		   .where(...)..ToListAsync();
    }
