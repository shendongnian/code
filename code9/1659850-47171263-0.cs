    [ServiceContract]
    public interface IPingService
    {
    	[OperationContract]
    	string Ping(string msg);
    }
