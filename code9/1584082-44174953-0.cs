    public interface IValueProvider<T>
    {
        T Value { get; }
    }
    
    public class Test
    {
        public static void Foo<T>(IValueProvider<T> provider)
        {
            var mystery = provider?.Value;
        }
    }
