    public class OrderId
    {
    	public string DepartmentId { get; }
    
    	public int OrderNumber { get; }
    
    	public OrderId(string departmentId, int orderNumber)
    	{
    		DepartmentId = departmentId;
    		OrderNumber = orderNumber;
    	}
    }
