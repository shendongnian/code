    public class WcfService : IWcfService 
    {
        [OperationContract(IsOneWay = false)]
        [FaultContract(typeof(Exception))]
        void DoSomething() { ... }
    }
