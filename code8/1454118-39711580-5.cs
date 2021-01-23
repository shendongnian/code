    public abstract class BaseFactory { }
    public abstract class BaseFactory<TImpl> : BaseFactory where TImpl : BaseFactory, new()
    {
        public static TImpl Create(Action<TImpl> itemConfiguration = null)
        {
            var child = new TImpl();
            itemConfiguration?.Invoke(child);
            return child;
        }
    }
