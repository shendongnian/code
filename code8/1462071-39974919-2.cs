    class Program
    {
        static void Main(string[] args)
        {
            Foo a = new Foo();
            a.FooPrint(); // should still print "Foo"
            Bar bar = new Bar();
            bar.foo.FooPrint(); // should print "Haha, only for Bar.foo."
            Console.Read();
        }
    }
    public class Foo
    {
        public Action FooPrint = () => Console.WriteLine("Foo");
    }
    public class Bar
    {
        public Foo foo = new Foo()
        {
            FooPrint = () => Console.WriteLine("Haha, only for Bar.foo.")
        };
    }
