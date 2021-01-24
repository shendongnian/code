    [ServiceContract]
    public interface IService1Core
    { 
        [OperationContract]
        public void DoSomething();
    }
    [ServiceContract]
    public interface IService1Extended : IService1Core
    { 
        [OperationContract]
        public void DoSomethingElse();
        [OperationContract]
        public void DoSomethingTotallyDifferent();
    }
