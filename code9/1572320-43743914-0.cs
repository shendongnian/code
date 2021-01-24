    public interface IFoo { }
    public class Foo : IFoo { }
    public class Bar : IFoo { }
    public class Whatever
    {
        public IFoo GetAFoo(bool thing)
        {
             if (thing)
                return new Foo();
             else
                return new Bar();
        }
    }
