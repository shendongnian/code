    // concrete machine factory
    public static class MachineFactory
    {
        // factory for the whole Mashine wrapper
        public static IMachineModel GetMachine()
        {
            var enabledSetters = CreateEnabledParameterSetters();
            return new MachineModel
            {
                A = GetDevice(enabledSetters, 0 /*A*/),
                B = GetDevice(enabledSetters, 1 /*B*/),
            };
        }
        // factory methods specify the connection from the wrapper classes to the Mashine
        private static Action<bool>[,] CreateEnabledParameterSetters()
        {
            return new Action<bool>[,]
            {
                { x => Mashine.Enable_A_X = x, x => Mashine.Enable_A_Y = x },
                { x => Mashine.Enable_B_X = x, x => Mashine.Enable_B_Y = x },
            };
        }
        private static IDeviceAxis GetDeviceAxis(Action<bool>[,] enabledSetters, int deviceIndex, int axisIndex)
        {
            return new MachineDeviceAxis
            {
                Enabled = new MachineParameter<bool>(enabledSetters[deviceIndex, axisIndex]),
                Position = null, // TODO
                Start = null, // TODO
            };
        }
        private static IDevice GetDevice(Action<bool>[,] enabledSetters, int deviceIndex)
        {
            return new MachineDevice
            {
                X = GetDeviceAxis(enabledSetters, deviceIndex, 0 /*X*/),
                Y = GetDeviceAxis(enabledSetters, deviceIndex, 1 /*Y*/),
            };
        }
    // ...
