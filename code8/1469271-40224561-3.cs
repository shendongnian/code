        public interface ISumFactory
        {
            ICalc GetCalc(int option);
        }
    
        public SumFactory : ISumFactory
        {
            public ICalc GetCalc(int option)
            {
                 if (option == 1)
                    return new NormalCalc();
                return null;
            }     
        }
    
    Now you should inject the factory interafce to SalaryManager class
    via it's constructor and use it when you need it:
    
        public class SalaryManager
        {
            private readonly ICalcFacotry _calcFactory;   
    
            public SalaryManager(ICalcFacotry clacFacotry)
            {
                _calcFactory = clacFacotry;
            }
        
            public int DoCalculation(int a, int b)
            {
                ICalc calc = _calcFactory.GetCalc(1);
                int Sum = calc.GetSum(a, b);
                //...
            }
        }
