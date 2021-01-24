    using (SqliteDbContext ctx = new SqliteDbContext())
    {
        var e1 = ctx.Events.Include(x => x.Contract).FirstOrDefault();
        MessageBox.Show(e1.Contract.Id.ToString());
    }
