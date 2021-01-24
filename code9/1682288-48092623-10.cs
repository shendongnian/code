    public interface ICommunicationLoggService
    {
        [OperationContract]
        bool SaveLog(Employee emp);
        [OperationContract]
        bool SaveLog(Studend emp);
        [OperationContract]
        bool SaveLog(Address emp);
    }
