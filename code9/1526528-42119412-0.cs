    [ServiceContract(CallbackContract=typeof(IMQServiceCallBack))]
    public interface IMQService
    {
        [OperationContract]
        void PublishMessage(Message message);
    
        [OperationContract]
        void Register();
    }
    
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class MQService : IMQService
    {
        public static List<CallBack> callbacks;
    
        public void Register()
        {
            callbacks.Add(OperationContext.Current.GetCallbackChannel<IMQServiceCallBack>());
        }
    }
