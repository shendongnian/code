    public interface ISomeInterface
    {
         object SomeProperty { get; set; }
    }
    public class A : ISomeInterface
    {
        public object SomeProperty { get; set; }
    }
    public static void Meth1(ISomeInterface obj)
    {
        var value = obj.SomeProperty;
        ...
    }
