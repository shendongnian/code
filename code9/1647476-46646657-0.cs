    public interface IMessageConfiguration
    {
        string Description { get; }
        byte Label { get; }
        ushort LSB { get; }
        ushort MSB { get; }
        double Resolution { get; }
        int SignBit { get; }
        string Title { get; }
        string Units { get; }
    }
    public interface IMessageConfiguration<T> : IMessageConfiguration {
        uint Encode(T data);
        T Decode(uint message);
    }
