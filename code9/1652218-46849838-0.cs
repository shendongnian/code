    var ctx = ApplicationContext();
    using(var tr = ctx.Database.BeginTransaction())
    {
        ctx.SaveChanges();
        // Not sure if at this point the connection is still open
        // or not disposed. You need to experiment here.
        using (SqlCommand command = new SqlCommand(query, ctx.Database.Connection))
        {
             command.ExecuteNonQuery();
             tr.Commit();
        }
    }
