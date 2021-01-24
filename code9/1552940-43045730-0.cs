    public interface IParameter
    {
        void DoSomething();
    }
    public abstract class Parameter<T>
    {
        protected T value;
        public T Value
        {
            get { return value; }
            set { this.value = value; }
        }
        protected Parameter(T startingValue)
        {
            value = startingValue;
        }
    }
    public class FloatParameter : Parameter<float>, IParameter
    {
        public FloatParameter(float startingValue) : base(startingValue) { }
        public void DoSomething()
        {
            Console.WriteLine(value);
        }
    }
    public class IntParameter : Parameter<int>, IParameter
    {
        public IntParameter(int startingValue) : base(startingValue) { }
        public void DoSomething()
        {
            Console.WriteLine(value);
        }
    }
