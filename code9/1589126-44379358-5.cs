    public abstract class ServicePropertyBase
    {
        public abstract object GetValue();
    }
    // Possibly this class should be sealed.
    public class ServiceProperty<T> : ServicePropertyBase
    {
        public ServiceProperty() { }
        public ServiceProperty(T value) { this.Value = value; }
        public T Value { get; set; }
        public override object GetValue()
        {
            return Value;
        }
    }
