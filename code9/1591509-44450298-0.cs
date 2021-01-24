    using(var context = new MyContext())
    {
        foreach(var table in new[] {typeof(table_a), typeof(table_b), typeof(table_c)})
        {
            var dbset = context.Set(table);
            var items = dbset.SqlQuery($"select * from {table.Name} where issue_id = {issue_id}").ToListAsync().Result;
            dbset.RemoveRange(items);
        }
        context.SaveChanges();
    }
