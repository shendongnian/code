    [ServiceContract]
    public interface IExampleService
    {
        [OperationContract]
        int GetInitValue();
    }
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ExampleService : IExampleService
    {
        private readonly int initValue;
        public ExampleService(int initValue)
        {
            this.initValue = initValue;
        }
        public int GetInitValue() => initValue;
    }
    // ...
    // public ServiceHost(object singletonInstance, params Uri[] baseAddresses)
    var host = new ServiceHost(new ExampleService(someValue)));
    host.AddServiceEndpoint(typeof(IExampleService),
        new WSHttpBinding(), "http://localhost:8080");
    host.Open();
