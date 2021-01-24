    public class Test<T1, T2>
    {
        private IValueObject<T1> _value1;
        private IValueObject<T2> _value2;
        public Test(IValueObject<T1> value1, IValueObject<T2> value2)
        {
            _value1 = value1;
            _value2 = value2;
        }
        
        void Write()
        {
            Console.WriteLine("Value1: " + _value1.Value);
        }
    }
