    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calling Foo(default(string).ToArg())...");
            Foo(default(string).ToArg());
            Console.WriteLine("Calling Foo(((string)null).ToArg())...");
            Foo(((string)null).ToArg());
            Console.WriteLine("Calling Foo(\"test\".ToArg())...");
            Foo("test".ToArg());
            Console.WriteLine("Calling Foo()...");
            Foo();
            Console.ReadLine();
        }
        public static void Foo(Argument<string> arg1 = null)
        {
            Console.WriteLine("arg1 is {0}null", arg1 == null ? "" : "not ");
            Console.WriteLine("arg1.IsSet={0}", arg1?.IsSet ?? false);
            Console.WriteLine("arg1.Value={0}", arg1?.Value ?? "(null)");
        }
    }
    public class Argument<T>
    {
        public Argument()
        {
            IsSet = false;
        }
        public Argument(T t)
        {
            _t = t;
            IsSet = true;
        }
        private T _t;
        public T Value { get { return _t; } set { _t = value; IsSet = true; } }
        public bool IsSet { get; private set; }
        public static implicit operator T(Argument<T> t) { return t._t; }
    }
    public static class Extensions
    {
        public static Argument<string> ToArg(this string s) { return new Argument<string>(s); }
    }
