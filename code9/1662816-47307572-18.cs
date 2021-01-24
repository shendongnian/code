    // inside factory
        // added implementation
        private class MachineParameter<TParam> : IAxisParameter<TParam>
        {
            Action<TParam> _setterFunction;
            public MachineParameter(Action<TParam> setter)
            {
                _setterFunction = setter;
            }
            public void Set(TParam value)
            {
                _setterFunction(value);
            }
        }
        // changed implementation
        private class MachineDeviceAxis : IDeviceAxis
        {
            public IAxisParameter<bool> Enabled { get; set; }
            public IAxisParameter<double> Position { get; set; }
            public IAxisParameter<bool> Start { get; set; }
        }
        // changed factory methods
        private static IDeviceAxis GetDeviceAxisA_X()
        {
            return new MachineDeviceAxis
            {
                Enabled = new MachineParameter<bool>(x => Mashine.Enable_A_X = x),
                Position = null, // TODO
                Start = null, // TODO
            };
        }
        private static IDeviceAxis GetDeviceAxisA_Y()
        {
            return new MachineDeviceAxis
            {
                Enabled = new MachineParameter<bool>(y => Mashine.Enable_A_Y = y),
                Position = null, // TODO
                Start = null, // TODO
            };
        }
        private static IDevice GetDeviceA()
        {
            return new MachineDevice
            {
                X = GetDeviceAxisA_X(),
                Y = GetDeviceAxisA_Y(),
            };
        }
        private static IDevice GetDeviceB()
        {
            // TODO same thing for device B
            return null;
        }
