    namespace FunctionCalls
    {
      class Functions
       {
          static public double addNumbers(double number1, double number2)
          {
            double result1 = number1 + number2;
            return result1;
          }
    
          static public double subtractNumbers(double number1, double number2)
          {
            double result2 = number1 - number2;
            return result2;
          }
    
          static public double avgNumbers(double number1, double number2)
          {
            double result3 = (number1 + number2) / 2;
            return result3;
          }
    
          static void Main(String[] args)
          {
              double result1 = 20.00;
              double result2 = 10.00;
              double sum, sub, avg;
    
              sum = Functions.addNumbers(result1, result2);
              sub = Functions.subtractNumbers(result1, result2);
              avg = Functions.avgNumbers(result1, result2);
    
              Console.WriteLine("The sum of your numbers is {0}", sum);
              Console.WriteLine("The difference of your numbers is {0}", sub);
              Console.WriteLine("The average of your numbers is {0}", avg);
    
              Console.ReadKey();
          }
       }
    }
 
