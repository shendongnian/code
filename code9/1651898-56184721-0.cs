    public interface IHasValue<T> {
        T Value { get; set; }
    }
    
    public abstract class Foo {
        public Guid Id { get; set; }
        public string Statement { get; set; }
    }
    
    public class Foostring : Foo, IHasValue<string> {
        string Value { get; set; }
    }
    
    public class FooInt : Foo, IHasValue<int> {
        int Value { get; set; }
    }
