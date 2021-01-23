    // in the class lib:
    public interface ISerialPortService
    {
        void SendSomething();
    }
    // in a one of the modules:
    public class OneModule : IModule
    {
        public OneModule( IUnityContainer container )
        {
            _container = container;
        }
        public void Initialize()
        {
            _container.RegisterType<ISerialPortService, MySerialPortImplementation>( new ContainerControlledLifetimeManager() );
        }
        private readonly IUnityContainer _container;
    }
    internal class MySerialPortImplementation : ISerialPortService
    {
        // ... implement all the needed functionality ...
    }
    // somewhere else...
    internal class SerialPortConsumer
    {
        public SerialPortConsumer( ISerialPortService serialPort )
        {
            _serialPort = serialPort;
        }
        public void SomeMethod()
        {
            _serialPort.SendSomething();
        }
        private readonly ISerialPortService _serialPort;
    }
