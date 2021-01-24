     namespace FunctionPractice
     {
          class Program
          {
             public int AddNumbers(int number1, int number2)
             {
                 int result = number1 + number2;
                 return result;
             }
             static void Main(string[] args)
             {
                 Console.WriteLine("Enter 2 numbers: ");
                 int firstNumber = Convert.ToInt16(Console.ReadLine());
                 int secondNumber = Convert.ToInt16(Console.ReadLine());
                Program program = new Program();
                int result = program.AddNumbers(firstNumber, secondNumber);
                Console.WriteLine(result);
            }
        }
    }
