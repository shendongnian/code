    List<SqlParameter> args = new List<SqlParameter>();
    args.Add(new SqlParameter("@parameterName", parameterValue));
    // Keep adding parameters like this
    using (MyDatabaseContext db = new MyDatabaseContext())
    {
        db.Database.ExecuteSqlCommand("StoredProcedureName", args.ToArray());
    }
