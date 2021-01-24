    [ServiceContract]
    public interface IServiceCommon<T>
    {
        [OperationContract]
        T GetData();
    }
