    public class Foo
    {
        public int Bar { get; set; }
    }
    static void Main(string[] args)
    {
        Foo foo = new Foo(); //same result with Foo foo = null;
        var baz = foo?.Bar;
        if (baz.HasValue) //Expected Error here, but compiles fine
        {
            throw new NotImplementedException();
        }
    }
