    create procedure sp_foo
        as
        begin
        	return 99
        end
    [Test]
    public void TestStoredProcedure()
    {
        using (var conn = new SqlConnection(@"Data Source=.\sqlexpress;Integrated Security=true; Initial Catalog=foo"))
        {
            var p = new DynamicParameters();
            p.Add("@foo", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            conn.Execute("sp_foo", p, commandType: CommandType.StoredProcedure);
            var b = p.Get<int>("@foo");
            Assert.That(b, Is.EqualTo(99));
        }
    }
