    [ServiceContract]
    public interface IServiceContract<T>
    {
        [OperationContract]
        Task<string> AddNewData(T arg1);
    }
