    public class Foo
    {
        public void FooPrint()
        {
            Console.Write("Foo");
        }
    }
    public class Wrapper : Foo
    {
        public new void FooPrint()
        {
            Console.Write("Haha, only for Bar.foo.");
        }
    }
    public class Bar
    {
        public Wrapper foo = new Wrapper();        
    }
