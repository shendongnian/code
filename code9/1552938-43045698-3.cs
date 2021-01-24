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
            }
        }
    }
    public class ParameterBase
    {
        protected object value;
        public virtual object Value
        {
            get { return value; }
            set { this.value = value; }
        }
    }
    public class FloatParameter : ParameterBase
    {
        public FloatParameter(float value)
        {
            Value = value;
        }
    }
    public class IntParameter : ParameterBase
    {
        public IntParameter(int value)
        {
            Value = value;
        }
    }
