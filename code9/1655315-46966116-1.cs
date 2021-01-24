     public class MathStuff
     {
         public static double Factorial(int n) => n == 1? 1 : n * Factorial(n - 1);
     }
    
     class Program
     {
         static void Main(string[] args)
         {
             Console.WriteLine(MathStuff.Factorial(10));
         }
     }
