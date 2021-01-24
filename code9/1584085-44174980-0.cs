    public interface IValueProvider<T>
    {
        T Value { get; }
    }
    public class Validator<T>
    {
        public Validator(IValueProvider<T> provider)
        {
            var providerValue = provider?.Value;
        }
    }
