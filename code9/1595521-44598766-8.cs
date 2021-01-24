    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MyClass<ConsoleKeyInfo>.Do(Console.ReadKey));
            Console.ReadKey();
        }
    }
    public static class MyClass<T>
    {
        public static object Do(Func<T> Method)
        {
            return Method();
        }
    }
