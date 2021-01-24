    class Program
    {
        static void Main(string[] args)
        {
            // no type specified in Parameter
            var storedParameters = new List<ParameterBase>();
            storedParameters.Add(new FloatParameter(3.5F));
            storedParameters.Add(new IntParameter(7));
            foreach (var p in storedParameters)
            {
                Console.WriteLine(p.Value);
                Console.WriteLine(p.ValueType);
            }
        }
    }
    public class ParameterBase
    {
        protected dynamic value;
        protected Type valueType;
        public virtual dynamic Value
        {
            get { return value; }
            set { this.value = value; }
        }
        public virtual Type ValueType
        {
            get { return valueType; }
            set { this.valueType = value; }
        }
    }
    public class FloatParameter : ParameterBase
    {
        public FloatParameter(float value)
        {
            Value = value;
            ValueType = value.GetType();
        }
    }
    public class IntParameter : ParameterBase
    {
        public IntParameter(int value)
        {
            Value = value;
            ValueType = value.GetType();
        }
    }
