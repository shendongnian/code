    public interface IMapper<T>
    {
    	T MapObject();
    	List<T> MapList();
    }
    
    public class OrderMapper : IMapper<OrderDetails>
    {
    	public OrderDetails MapObject()
    	{
    		//	mapping code...
    
    		return new OrderDetails();
    	}
    
    	public List<OrderDetails> MapList()
    	{
    		throw new NotImplementedException();
    	}
    }
    
    public class CustomerMapper : IMapper<CustomerDetails>
    {
    	public CustomerDetails MapObject()
    	{
    		//	mapping code...
    
    		return new CustomerDetails());
    	}
    
    	public List<CustomerDetails> MapList()
    	{
    		throw new NotImplementedException();
    	}
    }
