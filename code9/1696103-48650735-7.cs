    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        [FaultContract(typeof(SecurityFault))]
        int Divide(int number1, int number2);
    }
