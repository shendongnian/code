    public class Foo
    {
        public Action FooPrint {get; set;} = () => Console.Write("Foo");
    }
        
    public class Bar
    {
        public Foo foo = new Foo();
        public Bar()
        {
            foo.FooPrint = () => Console.Write("Haha, only for Bar.foo.");
        }
    }
