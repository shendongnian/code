    public interface ISettable<in T>
    {
        void Set(T value);
    }
    public interface IClickable
    {
        void Click();
    }
    public class Control<T> : ISettable<T>, IClickable
    {
        void ISettable<T>.Set(T value) => throw new NotImplementedException();
        void IClickable.Click() => throw new NotImplementedException();
    }
    public static class FluentExtensions
    {
        public static TControl Set<TControl, T>(this TControl source, T value)
            where TControl : ISettable<T>
        {
            source.Set(value);
            return source;
        }
        public static TControl Click<TControl>(this TControl source)
            where TControl : IClickable
        {
            source.Click();
            return source;
        }
    }
