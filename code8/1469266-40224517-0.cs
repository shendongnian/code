    public interface ISumFactory {
        ICalc GetSumObject(int option);
    }
    public class SumFactory : ISumFactory {
        public  ICalc GetSumObject(int option) {
            if (option == 1)
                return new NormalCalc();
            return null;
        }
    }
    public class SalaryManager {
        private ICalc CalcRef;
        public SalaryManager(ISumFactory factory) {
            CalcRef = factory.GetSumObject(1);
        }
        public int DoCalculation(int a, int b) {
            int Sum = CalcRef.GetSum(a, b);
            //Perform some other operation
            //
            //
            //...;
        }
    }
