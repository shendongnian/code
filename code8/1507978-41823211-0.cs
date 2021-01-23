    public class XUnitSqlCaptureInterceptor : EmptyInterceptor
    {
        public XUnitSqlCaptureInterceptor(ITestOutputHelper output)
    	{
    		this.Output = output;
    	}
    
    	public ITestOutputHelper Output { get; set; }
    
    	public override SqlString OnPrepareStatement(SqlString sql)
    	{
    		this.Output.WriteLine(sql.ToString());
    
    		return sql;
    	}
    }
