    public enum Device { A, B }
    public enum Axis { X, Y }
    // your control class
    public class Control
    {
        public IMachineModel devControl;
        public Control()
        {
            // MachineFactory see below
            devControl = MachineFactory.GetMachine();
        }
        public void Disable(Device dev, Axis dim)
        {
            GetAxis(dev, dim).Disable();
        }
        public void Enable(Device dev, Axis dim)
        {
            GetAxis(dev, dim).Enable();
        }
        private IDeviceAxis GetAxis(Device dev, Axis dim)
        {
            var device = GetDevice(dev);
            switch (dim)
            {
                case Axis.X:
                    return device.X;
                case Axis.Y:
                    return device.Y;
                default:
                    throw new ArgumentException("Invalid Axis", "dim");
            }
        }
        private IDevice GetDevice(Device dev)
        {
            switch (dev)
            {
                case Device.A:
                    return devControl.A;
                case Device.B:
                    return devControl.B;
                default:
                    throw new ArgumentException("Invalid Device", "dev");
            }
        }
    }
