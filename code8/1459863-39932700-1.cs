    public abstract class SensorDevice : Device
    {
        public IEnumerable<Platform> Platforms;
        public override bool IsCompatibleWith(Platform platform)
        {
            // I'm using type comparison again.
            return this.Platforms.Any(p => p.GetType() == platform.GetType());
        }
        public bool IsCompatibleWith(CaptureDevice cd)
        {
            // We are compatible if capture is compatible with one of my platforms. 
            return this.Platforms.Any(p => cd.IsCompatibleWith(p));
        }
    }
