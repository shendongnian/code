    public List<Data> Search (string param1, string param2)
    {
        IQueryable<Data> query = db.SomeTable;
        if (!String.IsNullOrEmpty(param1))
            query = query.Where(m => m.Field1 == param1); // might use contain depending on your use case
        if (!String.IsNullOrEmpty(param2))
            query = query.Where(m => m.Field2 == param2);
        return query.ToList();
    }
