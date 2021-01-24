    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Foo().ToString());
            Console.ReadLine();
        }
    }
    [ThrowExceptionException]
    public class Foo
    {
    }
    public class ThrowExceptionAttribute : Attribute
    {
        public ThrowExceptionAttribute()
        {
            throw new NotImplementedException();
        }
    }
