    [ServiceContract]
    public interface IExampleService
    {
        [OperationContract]
        int GetInitValue();
    }
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
    host.Open();
