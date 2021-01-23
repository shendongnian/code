    public class MyClassFactory
    {
        public IMyClass Create()
        {
            if (DateTime.Today.DayOfWeek = DayOfWeek.Friday)
            {
                return new MyClass(new ASomething1(), new ASomething2());
            }
    
            return new MyClass(new BSomething1(), new BSomething2());
        }
    }
