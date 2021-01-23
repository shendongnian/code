    public class Foo : BaseFactory<Foo>
    {
        public override Foo WithSomeProp()
        {
            return new Foo();
        }
    }
    public class Bar : BaseFactory<Bar>
    {
        public override Bar WithSomeProp()
        {
            return new Bar();
        }
    }
