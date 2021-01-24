    public class Program
    {
        public static void Main(string[] args)
        {
            Method(() => GetObject());
        }
        public static IInterface GetObject() => null;
        public static void Method(Func<IInterface> func) =>
            Console.WriteLine("First");
        public static void Method(Func<Task<IInterface>> funcAsync) =>
            Console.WriteLine("Second");
    }
    public interface IInterface { }
