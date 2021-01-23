    // Throws exception when BaseFactory.Create() is called, even though this compiles fine.
    public class Bar : BaseFactory<Foo>
    {
        protected override Foo WithSomeProp()
        {
            return new Foo();
        }
    }
