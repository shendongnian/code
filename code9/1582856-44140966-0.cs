    // in the interface-assembly:
    public interface IDriver
    {
        bool ReadSensor();
    }
    // in module a:
    internal class MyDriver : IDriver ...
    public class MyModuleA : IModule
    {
        public void Initialize()
        {
            _container.RegisterType<IDriver, MyDriver>( new ContainerControlledLifetimeManager() );
        }
    }
    // in module b:
    internal class MyViewModel
    {
        public MyViewModel( IDriver theHardware ) ...
    }
