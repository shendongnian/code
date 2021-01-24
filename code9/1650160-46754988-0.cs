    public interface IFoo<TValue>
    {
        TValue SomeValue { get; set; }
    }
    public class StringFoo : IFoo<string>
    {
        public string SomeValue { get; set; }
    }
    public class DoubleFoo : IFoo<double>
    {
        public double SomeValue { get; set; }
    }
    public class Foo<TValue> : IFoo<TValue>
    {
        public TValue SomeValue { get; set; }
    }
    public abstract class Bar
    {
    }
    public class Bar<TValue> : Bar, IFoo<TValue>
    {
        public TValue SomeValue { get; set; }
    }
    public static class Verify
    {
        public static void QuestionArray()
        {
            var foos = new IFoo<object>[]
            {
                (IFoo<object>) new StringFoo { SomeValue = "a value" },
                (IFoo<object>) new DoubleFoo { SomeValue = 123456789 }
            };
        }
        public static void BadAnswerArray()
        {
            var foo = new IFoo<object>[]
            {
                (IFoo<object>) new Foo<string>(),
                new Foo<object>(),
            };
        }
        public static void GoodAnswer()
        {
            var foo = new Bar[]
             {
                new Bar<string>(),
                new Bar<object>(),
                new Bar<double>()
             };
        }
    }
