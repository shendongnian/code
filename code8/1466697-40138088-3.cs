    public interface IHandler //Can handle many types
    {
        T Process<T>(int process);
        bool CanProcess<T>();
    }
    public interface IHandler<T> //Can handle a single type
    {
        T Process(int process);
    }
