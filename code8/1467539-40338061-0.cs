    public interface IRabitMqClientFactory
    {
    	IRabitMqClientFactory Create(string baseServiceName);
    }
    
    public class RabitMqClientFactory : IRabitMqClientFactory
    {
    	public RabitMqClientFactory(IConnectionFactory connectionFactory){
    		_connectionFactory = connectionFactory;
    	}
    
    	public IRabitMqClientFactory Create(string baseServiceName)
    	{
    		_baseServiceName = baseServiceName;
    	}
    }
