    [ServiceContract]
    public interface IServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        Task SendMessageBack(string message);
    }
    
    [ServiceContract(CallbackContract = typeof(IServiceCallback))]
    public interface IService
    {
        [OperationContract(IsOneWay = true)]
        Task DoSomething(string parameter);
    }
