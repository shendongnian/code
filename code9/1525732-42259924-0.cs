    public interface IService
    {
        [OperationContract]
        [FaultContract(typeof(WrappedExceptionFault))]
        bool DoSomething(string setting);
    }
    [DataContract]
    public class WrappedExceptionFault
    {
        [DataMember]
        public string Message { get; set; }
    }
    public class Service : IService
    {
        public bool DoSomething(string setting)
        {
            try
            {
                throw new ArgumentException(setting);
            }
            catch (Exception ex)
            {
                throw WrapException(ex);
            }
        }
        private FaultException<WrappedExceptionFault> WrapException(Exception ex)
        {
            string message = ex.GetBaseException().Message;
            Console.WriteLine(string.Format("Exception: {0}", message));
            WrappedExceptionFault fault = new WrappedExceptionFault()
            {
                Message = message,
            };
            return new FaultException<WrappedExceptionFault>(fault, new FaultReason(message));
        }
    }
