    public interface IFlyable<out TSpeed>
        where TSpeed : IVerticalSpeed
    {
        TSpeed Speed { get; set; }
    }
