    List<Table1> list1;
    List<Table2> list2;
    using (var cn = new SqlConnection(@"Connection String"))
    {
        cn.Open();
        using (var cmd = cn.CreateCommand())
        {
            cmd.CommandText = "SELECT * FROM Table1; SELECT * FROM Table2";
            var reader = cmd.ExecuteReader(); 
            using (var db = new YourDbContext())
            {
                var context = ((IObjectContextAdapter)db).ObjectContext;
                list1 = context.Translate<Table1>(reader).ToList();
                reader.NextResult();
                list2 = context.Translate<Table2>(reader).ToList();
            }
        }
    }
