    [ServiceContract]
    public interface IClientConnectionService
    {
        [OperationContract]
        bool Connect(string message);
    }
