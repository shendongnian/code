    public class A 
    {
    	public int Id {get; set;}
    	public virtual List<AB> ABs { get; set; }
    }
    
    public class B
    {
    	public int Id {get; set;}
    	public virtual List<AB> BAs {get; set; }
    }
    
    public class AB
    {
    	public int AId {get;set;}
    	public virtual A {get; set;}
    	
    	public int BId {get;set;}
    	public virtual B {get; set;}
    }
