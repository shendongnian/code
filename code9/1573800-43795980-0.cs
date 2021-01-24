    namespace Calculator {
      public class CalculatorClass {
        //METHODS
        public bool TryDivide(object num1, object num2, out double doubleVal) {
          doubleVal = 0;
    
          try {
            if (num1 == null || num2 == null)
              return false;
    
            double num = 0, den = 0;
            bool parseResult;
    
            if (num1 is double)
              num = (double)num1;
            else {
              parseResult = double.TryParse(num1.ToString(), out num);
              if (!parseResult)
                return false;
            }
    
            if (num2 is double)
              den = (double)num2;
            else {
              parseResult = double.TryParse(num2.ToString(), out den);
              if (!parseResult)
                return false;
            }
    
            doubleVal = num / den;
            return true;
    
          } catch {
            throw; //may change to return false too
          }
        }
      }
    }
