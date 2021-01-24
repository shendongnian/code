    [ServiceContract]
    public interface IService1
    { 
        [OperationContract]
        public void DoSomething();
        [OperationContract]
        public void DoSomethingElse();
        [OperationContract]
        public void DoSomethingTotallyDifferent();
    }
