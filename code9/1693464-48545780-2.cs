    public interface ISettable<in T>
    {
        ISettable<T> Set(T value);
    }
    public class Control<T> : ISettable<T>
    {
        public ISettable<T> Set(T value)
        {
            // Do stuff with the current instance..
            return this;
        }
    }
