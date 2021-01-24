    abstract class ClassBase
    {
	    public int Key { get; set; }
    }
    
    public class ClassA : ClassBase
    {
	    public int Col1 { get; set; }
	    public int Col2 { get; set; }
    }
    public class ClassB : ClassBase
    {
	    public int Col3 { get; set; }
	    public int Col4 { get; set; }
    }
