    public enum DeviceOrientations
    {
        LandscapeLeft,
        LandscapeRight,
        Others
    }
    public interface ICommonAction
    {
        DeviceOrientations GetOrientation();
    }
