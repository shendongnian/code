    public interface ICommunicationLoggService
    {
        [OperationContract]
        bool SaveLog<TEntity>(TEntity emp);
    }
