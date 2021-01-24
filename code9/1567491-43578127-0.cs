    using System;
    namespace Sum
    {
       public class Program
       {
           public static void Main(string[] args)
           {
               int number;
               Console.WriteLine("number\t" + "square\t" + "cube");
               Console.WriteLine("-----------------------------");
               for (int i = 0; i <= 20; i += 2)
               {
                   number = i;
                   int total = 0;
                   int k = 0;
                   do
                   {
                       Console.Write(number + "\t");
                       total += number;
                       number *= i;
                       k++;
                   } while (k < 3);
                   Console.WriteLine("Total is "+total);
                   Console.WriteLine();
               }
               Console.WriteLine("---------------------------------------");
            }
        }
    }
