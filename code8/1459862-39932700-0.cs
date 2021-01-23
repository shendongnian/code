    public abstract class CaptureDevice : Device
    {
        public Platform Platform;
        public override bool IsCompatibleWith(Platform platform)
        {
            // I'm using type comparison for the sake of simplicity,
            // but you can implement different business rules in here.
            return this.Platform.GetType() == platform.GetType();
        }
        public bool IsCompatibleWith(SensorDevice sd)
        {
           // We are compatible if sensor is compatible with my platform.
            return sd.IsCompatibleWith(this.Platform);
        }
    }
