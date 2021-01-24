    public class Parameter<T> : Parameter
    {
        public Parameter(string name, ParameterValue<T> value) : base(name)
        {
            Value = value;
        }
    
        public ParameterValue<T> Value { get; set; }
    }
