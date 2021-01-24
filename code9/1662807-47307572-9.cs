    public interface IAxisParameter<TParameter>
    {
        void Set(TParameter value);
    }
    public interface IDeviceAxis
    {
        IAxisParameter<bool> Enabled { get; }
        IAxisParameter<double> Position { get; }
        IAxisParameter<bool> Start { get; }
    }
