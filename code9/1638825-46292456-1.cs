    void Main()
    {
    	DumpExp(r => new { r.EmployeeID, r.Name });
    }
    
    public void DumpExp<TKey>(Expression<Func<Foo, TKey>> expr)
    {
    	expr.Dump();
    }
    
    public class Foo
    {
    	public string EmployeeID;
    	public string Name;
    }
