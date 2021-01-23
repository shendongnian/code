        public class SalaryManager
        {
            private readonly ICalc _calc;
    
            public SalaryManager(ICalc clac)
            {
                _calc = calc;
            }
    
            public int DoCalculation(int a, int b)
            {
                int Sum = _calc.GetSum(a, b);
                //...
            }
        }
    
    Now it is easy to inject a mocked instance of ICalc to your class,
    just create the a mock of ICalc using moq and pass it to the calss
    via the constructor.
