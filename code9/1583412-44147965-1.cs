    public class HomeViewModel
    {
        IBatteryService _batteryLevel;
        public HomeViewModel()
        {
            //You will initialize your instance either using DI (Dependency Injection or by using ServiceLocator.
        }
        public double GetDeviceBatteryLevel()
        {
             // At this moment the VM doesn't know which implementation is used and it actually doesn't care.
             return _batteryLevel.GetBatteryLevel();
        }
    }
