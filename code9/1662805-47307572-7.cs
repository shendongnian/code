    // concrete machine factory
    public static class MachineFactory
    {
        // factory for the whole Mashine wrapper
        public static IMachineModel GetMachine()
        {
            return new MachineModel
            {
                A = GetDeviceA(),
                B = GetDeviceB(),
            };
        }
        // factory methods specify the connection from the wrapper classes to the Mashine
        private static IDevice GetDeviceA()
        {
            return new MachineDevice(x => Mashine.Enable_A_X = x, y => Mashine.Enable_A_Y = y);
        }
        private static IDevice GetDeviceB()
        {
            return new MachineDevice(x => Mashine.Enable_B_X = x, y => Mashine.Enable_B_Y = y);
        }
        // concrete implementations can be used for the target Mashine
        private class MachineDeviceAxis : IDeviceAxis
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
        private class MachineDevice : IDevice
        {
            public MachineDevice(Action<bool> xSetter, Action<bool> ySetter)
            {
                X = new MachineDeviceAxis(xSetter);
                Y = new MachineDeviceAxis(ySetter);
            }
            public IDeviceAxis X { get; private set; }
            public IDeviceAxis Y { get; private set; }
        }
        private class MachineModel : IMachineModel
        {
            public IDevice A { get; set; }
            public IDevice B { get; set; }
        }
    }
