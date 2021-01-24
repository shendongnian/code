    public interface IFoo { }
    public interface IFooConfig { }
    public class Foo : IFoo
    {
        private readonly IFooConfig _config;
        public Foo(IFooConfig config)
        {
            _config = config;
        }
    }
    public class FooConfigA : IFooConfig { }
    public class FooConfigB : IFooConfig { }
