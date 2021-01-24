    public interface IProcessable
    {
    	bool isProcessed { get; set; }
    }
    public class A : IProcessable
    {
    	public int CustID { get; set; }
    	public bool isProcessed { get; set; }
    }
    
    public class B : IProcessable
    {
    	public int EmpId { get; set; }
    	public bool isProcessed { get; set; }
    }
