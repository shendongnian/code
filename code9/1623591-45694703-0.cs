    [ServiceContract]
    public interface IFirstService
    {
		//Methods
    }
    [ServiceContract]
    public interface ISecondService
    {
		//Methods
    }
	
	[ServiceBehavior]
	public class YourClass: IFirstService, ISecondService
	{
		//Methods
	}
