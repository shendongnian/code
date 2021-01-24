    interface IOperatingSystem
    {
        void StartService(string name);
    }
    class OperatingSystem : IOperatingSystem
    {
        public virtual void StartService(string name) {
            var windowsService = new ServiceController(name);
            windowsService.Start();
        }
    }
    class SomeType : ISomeType
    {
        private readonly IOperatingSystem _operatingSystem;
        public SomeType(IOperatingSystem operatingSystem)
        {
            _operatingSystem = operatingSystem;
        }
        public void Configure()
        {
            _operatingSystem.StartService("msdtc");
        }
    }
