    void Main()
    {
    	IEnumerable<SomeTable> arrayOfSomeTable = 
    		new SomeTable[] { new SomeTable(), new SomeTable() };
    	
    	IEnumerable<SomeTable> listOfSomeTable = 
    		new List<SomeTable> { new SomeTable(), new SomeTable() };
    	
    	Stack<SomeOtherTable> stackOfOtherTable = new Stack<SomeOtherTable>();
    	stackOfOtherTable.Push(new SomeOtherTable());
    	stackOfOtherTable.Push(new SomeOtherTable());
    	IEnumerable<SomeOtherTable> stackOtherTable = stackOfOtherTable;
    
    	ShowTableDef(arrayOfSomeTable);
    	ShowTableDef(listOfSomeTable);
    	ShowTableDef(stackOfOtherTable);
    }
    
    public void ShowTableDef<T>(IEnumerable<T> objectToLog) where T : ITable
    {
    	foreach (ITable tbl in objectToLog)
    	{
    		Console.WriteLine(tbl.GetTableDefinition());
    	}
    }
    
    public interface ITable { string GetTableDefinition(); }
    
    public class SomeTable : ITable
    {
    	public string GetTableDefinition() { return "foo"; }
    }
    
    public class SomeOtherTable : ITable
    {
    	public string GetTableDefinition() { return "bar"; }
    }
