    public abstract class BaseFactory { }
    public abstract class BaseFactory<TImpl> : BaseFactory where TImpl : BaseFactory
    {
        public abstract TImpl WithSomeProp();
    }
