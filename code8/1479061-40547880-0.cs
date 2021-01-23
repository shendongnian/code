    class Program
    {
        public static void Main()
        {
            Number n = new Number();
            IOne one = n.GetNumberObject<One>();
            one.PrintOne();
            ITwo two = n.GetNumberObject<Two>();
            two.PrintTwo();
        }
        public interface INumbers
        {
            T GetNumberObject<T>() where T : new();
        }
        public class Number : INumbers
        {
            public T GetNumberObject<T>() where T : new()
            {
                return new T();
            }
        }
        public interface IOne
        {
            void PrintOne();
        }
        public interface ITwo
        {
            void PrintTwo();
        }
        class One : IOne
        {
            public void PrintOne()
            {
                Console.WriteLine("One");
            }
        }
        class Two : ITwo
        {
            public void PrintTwo()
            {
                Console.WriteLine("Two");
            }
        }
    }
