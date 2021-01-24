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
    class Program
    {
        static void Main(string[] args)
        {
            Integers i = new Integers();
            Bools b = new Bools();
            Console.WriteLine(i.Reverse(5));
            Console.WriteLine(b.Reverse(true));
        }
    }
