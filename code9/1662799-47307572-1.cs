    // your control class
    public class Control
    {
        public IMachineModel devControl;
        public Control()
        {
            devControl = MachineFactory.GetMachine();
        }
        public void Disable(Device dev, Axis dim)
        {
            IDeviceAxis axis = GetAxis(dev, dim);
            axis.Disable();
        }
        public void Enable(Device dev, Axis dim)
        {
            IDeviceAxis axis = GetAxis(dev, dim);
            axis.Enable();
        }
        private IDeviceAxis GetAxis(Device dev, Axis dim)
        {
            IDevice device;
            switch (dev)
            {
                case Device.A:
                    device = devControl.A;
                    break;
                case Device.B:
                    device = devControl.B;
                    break;
                default:
                    throw new ArgumentException("Invalid Device", "dev");
            }
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
    }
