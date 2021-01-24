     using System;
     using System.Collections.Generic;
     using System.Linq;
     using System.Text;
     using System.Threading.Tasks;
     namespace ConsoleApplication1
     {
        class Program
        {
           static void Main(string[] args)
           {
            int argument = 10;//test argument
            Console.WriteLine($"The argument is={argument}");
            Console.WriteLine("The argument is={0}", argument);
            Console.WriteLine(String.Format("The argument is = {0}", argument));//Otra forma        
            Console.ReadKey();
        }
    }
}
