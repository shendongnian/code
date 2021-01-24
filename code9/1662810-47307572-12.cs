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
    // general device that has two axis, but doesn't care about anything else
    public interface IDevice
    {
        IDeviceAxis X { get; }
        IDeviceAxis Y { get; }
    }
    // data model for an alternative Mashine representation
    public interface IMachineModel
    {
        IDevice A { get; }
        IDevice B { get; }
    }
