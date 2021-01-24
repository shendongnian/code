    public interface IClientCallback
    {
        [OperationContract]
        bool FireInformClient(ClientInfo clientInfo);
    }
