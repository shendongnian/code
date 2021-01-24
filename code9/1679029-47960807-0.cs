    public interface IInterface<T>
    {
        T Reverse(T value);
    }
    
    public class Integers : IInterface<int>
    {
        public int Reverse(int value)
        {
            return -value;
        }
    }
    
    public class Bools : IInterface<bool>
    {
        public bool Reverse(bool value)
        {
            return !value;
        }
    }
