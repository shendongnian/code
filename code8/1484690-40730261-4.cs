    public interface IFactory
    {
    }
    public class Factory : IFactory
    {
    }
    public interface IHasFactory
    {
        IFactory Factory { get; }
    }
    [DataContract]
    public abstract class HasFactoryBase : IHasFactory
    {
        [ThreadStatic]
        static IFactory deserializedFactory;
        static IFactory DeserializedFactory
        {
            get
            {
                return deserializedFactory;
            }
            set
            {
                deserializedFactory = value;
            }
        }
        public static IDisposable SetDeserializedFactory(IFactory factory)
        {
            return new PushValue<IFactory>(factory, () => DeserializedFactory, val => DeserializedFactory = val);
        }
        IFactory factory;
        public IFactory Factory { get { return factory; } }
        public HasFactoryBase(IFactory factory)
        {
            this.factory = factory;
        }
        [OnDeserializing]
        void OnDeserializing(StreamingContext context)
        {
            this.factory = DeserializedFactory;
        }
    }
    public struct PushValue<T> : IDisposable
    {
        Action<T> setValue;
        T oldValue;
        public PushValue(T value, Func<T> getValue, Action<T> setValue)
        {
            if (getValue == null || setValue == null)
                throw new ArgumentNullException();
            this.setValue = setValue;
            this.oldValue = getValue();
            setValue(value);
        }
        #region IDisposable Members
        // By using a disposable struct we avoid the overhead of allocating and freeing an instance of a finalizable class.
        public void Dispose()
        {
            if (setValue != null)
                setValue(oldValue);
        }
        #endregion
    }
    [DataContract]
    public class Foo : HasFactoryBase
    {
        public Foo(IFactory factory)
            : base(factory)
        {
            this.Bars = new List<Bar>();
        }
        [DataMember]
        public List<Bar> Bars { get; set; }
    }
    [DataContract]
    public class Bar : HasFactoryBase
    {
        public Bar(IFactory factory) : base(factory) { }
    }
