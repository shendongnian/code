    public class Program
    {
        static void Main(string[] args)
        {          
            try
            {
                List<IParameter> storedParameters = new List<IParameter>();
                storedParameters.Add(new FloatParameter(2f));
                storedParameters.Add(new IntParameter(7));
                foreach (IParameter p in storedParameters)
                {
                    Console.WriteLine(p.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    
    public interface IParameter
    {
        object value { get; }
    }
    public class Parameter<T> : IParameter
    {
        public object value { get; protected set; }
        public virtual T Value
        {
            get { return (T)value; }
            set { this.value = value; }
        }
               
        protected Parameter(T startingValue)
        {
            value = startingValue;
        }
    }
    public class FloatParameter : Parameter<float>
    {
        public FloatParameter(float startingValue) : base(startingValue){ }
    }
    public class IntParameter : Parameter<int>
    {
        public override int Value
        {
            get { return (int)value; }
            set { this.value = value > 100 ? 100 : value; }
        }
        public IntParameter(int startingValue) : base (startingValue) { }
    }
