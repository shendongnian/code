    [ServiceContract]
    public interface IWebService
    {
        [OperationContract]
        SessionId BeginNewSession();
        [OperationContract]
        void DoSomething(SessionId id, ...);
        [OperationContract]
        void EndSession(SessionId id);
    }
