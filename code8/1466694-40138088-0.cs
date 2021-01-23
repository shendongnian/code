    public interface IHandler
    {
        T Process<T>(int process);
        bool CanProcess<T>();
    }
    public interface IHandler<T>
    {
        T Process(int process);
    }
