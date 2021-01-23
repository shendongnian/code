    public interface IService { string DoThisThing(); }
    public class FooService : IService
    {
        public string DoThisThing()
        {
            return "Foo";
        }
    }
    public class BarService : IService
    {
        public string DoThisThing()
        {
            return "Bar";
        }
    }
