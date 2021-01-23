    [ServiceContract]
    public interface IService:
    {
        [OperationContract]
        [FaultContract(typeof(MyResultClass))]
        void DoStuff();
    }
