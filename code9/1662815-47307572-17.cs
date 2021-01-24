    public class Control
    {
        public void Disable(Device dev, Axis dim)
        {
            GetAxis(dev, dim).Enabled.Set(false);
        }
        public void Enable(Device dev, Axis dim)
        {
            GetAxis(dev, dim).Enabled.Set(true);
        }
        // rest of the code as in the original answer above
    }
