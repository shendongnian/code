    void Main()
    {
    	DateTime? s=null;
    	DateTime? e=DateTime.Today;
    	Test(s,e);
    }
    
    void Test(DateTime? startDate, DateTime? endDate)
    {
        var cs=@"data source=(local);database=test;integrated security=true";
    	using (var con = new SqlConnection(cs))
    	{
    		con.Open();
    		var t = con.Query<string>("TestIt", new { startDate, endDate},
                    commandType: CommandType.StoredProcedure);
    
    		$"List: {t.FirstOrDefault()}".Dump();
    	}
    }
    
