       [ServiceContract]
    //[FaultContract(typeof(object))]
    [ServiceKnownType(typeof(busSample))]
    public interface IUPSBusinessTier
    {
        [FaultContract(typeof(object))]
        [OperationContract]
        string TestMethod1(string astrName);
        [FaultContract(typeof(object))]
        [OperationContract]
        void TestMethod2(busSample abusSample);
