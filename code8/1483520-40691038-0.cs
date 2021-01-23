    abstract class Base
    {
        public abstract static string Value { get; }
        public abstract string InstanceValue { get { return Value; } }
    }
