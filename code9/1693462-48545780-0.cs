    public interface ISettable<in T>
    {
        void Set(T value);
    }
    public class Control<T> : ISettable<T>
    {
        public void Set(T value)
        {
            throw new NotImplementedException();
        }
    }
