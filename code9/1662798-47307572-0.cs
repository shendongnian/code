    public static class Mashine
    {
        public static bool Enable_B_X { get; set; }
        public static bool Enable_B_Y { get; set; }
        public static bool Enable_A_X { get; set; }
        public static bool Enable_A_Y { get; set; }
    }
    /// <summary>
    /// Represents a single axis of a single device
    /// </summary>
    public interface IDeviceAxis
    {
        void Enable();
        void Disable();
    }
    // concrete implementation can be used for the target Mashine
    class MachineDeviceAxis : IDeviceAxis
    {
        Action<bool> _setterFunction;
        public MachineDeviceAxis(Action<bool> setter)
        {
            _setterFunction = setter;
        }
        public void Enable()
        {
            _setterFunction(true);
        }
        public void Disable()
        {
            _setterFunction(false);
        }
    }
    // general device that has two axis, but doesn't care about anything else
    public interface IDevice
    {
        IDeviceAxis X { get; }
        IDeviceAxis Y { get; }
    }
    // concrete implementation can be used for for the target Mashine
    class MachineDevice : IDevice
    {
        public MachineDevice(Action<bool> xSetter,Action<bool> ySetter)
        {
            X = new MachineDeviceAxis(xSetter);
            Y = new MachineDeviceAxis(ySetter);
        }
        public IDeviceAxis X { get; private set; }
        public IDeviceAxis Y { get; private set; }
    }
    // data model for an alternative Mashine representation
    public interface IMachineModel
    {
        IDevice A { get; }
        IDevice B { get; }
    }
    // concrete machine factory
    public static class MachineFactory
    {
        // concrete machine model that will be constructed in this factory
        private class MachineModel : IMachineModel
        {
            public IDevice A { get; set; }
            public IDevice B { get; set; }
        }
        // factory methods specify the connection from the wrapper classes to the actual Mashine
        private static IDevice GetDeviceA()
        {
            return new MachineDevice(x => Mashine.Enable_A_X = x, y => Mashine.Enable_A_Y = y);
        }
        private static IDevice GetDeviceB()
        {
            return new MachineDevice(x => Mashine.Enable_B_X = x, y => Mashine.Enable_B_Y = y);
        }
        // factory for the whole Mashine wrapper
        public static IMachineModel GetMachine()
        {
            return new MachineModel
            {
                A = GetDeviceA(),
                B = GetDeviceB(),
            };
        }
    }
    public enum Device { A, B }
    public enum Axis { X, Y }
