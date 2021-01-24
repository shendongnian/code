    public class A1
    {
    	public int id { get; set; }
    	public string name { get; set; }
    }
    
    public class A2
    {
    	public int id2 { get; set; }
    	public string name2 { get; set; }
    }
    
    public class AModel 
    {
    	public A1 Emp { get; set; }
        public A2 EmpMarks { get; set; }
    }
    
    
    [Route("Save")]
    [HttpPost]
    public string Save(AModel aData)
    {
    	// ... your logic here
    }
