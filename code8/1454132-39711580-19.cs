    public abstract class BaseFactory { }
    public abstract class BaseFactory<TImpl> : BaseFactory where TImpl : BaseFactory
    {
        protected abstract TImpl WithSomeProp();
        public TImpl Create()
        {
            Type myType = this.GetType();
            if (typeof(TImpl) != myType)
            {
                throw new InvalidOperationException($"{myType.Name} can not create instances of itself because the generic argument it provided to the factory is of a different Type.");
            }
            return this.WithSomeProp();
        }
    }
    public class Foo : BaseFactory<Foo>
    {
        protected override Foo WithSomeProp()
        {
            return new Foo();
        }
    }
    public class Bar : BaseFactory<Bar>
    {
        protected override Bar WithSomeProp()
        {
            return new Bar();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var obj1 = new Bar();
            // Works
            Bar obj2 = obj1.Create();
            // Won't compile because obj1 returns Bar.
            Foo obj3 = obj1.Create();
        }
    }
