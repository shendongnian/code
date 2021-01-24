    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       modelBuilder.Query<YourModel>();
    }
----
    SqlParameter value1Input = new SqlParameter("@Param1", value1 ?? (object)DBNull.Value);
    SqlParameter value2Input = new SqlParameter("@Param2", value2 ?? (object)DBNull.Value);
    List<YourModel> result;
    using (var db = new MyDbContext(_options))
    {
        result = await db.Query<YourModel>().FromSql("STORED_PROCEDURE @Param1, @Param2", value1Input, value2Input).ToListAsync();
    }
