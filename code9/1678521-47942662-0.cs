    public interface IDevice
    {
        void WhateverIWantToDoWIthDevice();
    }
    
    public class DeviceIdentifier
    {
        private List<DeviceFactory> factories = new List<DeviceFactory>();
        public void AddDeviceType(DeviceFactory factory) => factories.Add(factory);
        public IDevice BuildDeviceFromBaudrate(int baudrate) => factories.FirstOrDefault(f => f.BaudRate == baudrate)?.Builder();
    }
    
    public class DeviceFactory
    {
        public int BaudRate { get; set; }
        public Func<IDevice> Builder { get; set; }
    }
