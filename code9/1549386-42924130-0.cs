    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace SoloLearn
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("What is the number you want to convert?");
                string num = Console.ReadLine();
                Console.WriteLine("In what base is this number?");
                int mathBase = int.Parse(Console.ReadLine());
                double output = 0;
                int j = 0;
                char[] nums = num.ToCharArray();
                for(int i=num.Length - 1; i>=0; i--) {
                   output = output + Math.Pow(mathBase,i) * Int32.Parse(nums[j].ToString()) * 1;
                   Console.WriteLine("i: " + i +", j:" + j + ", nums[j]: " + nums[j] + ", output: " + output + ", mathBase: " + mathBase + ", " + Math.Pow(mathBase,i) + ".");
                   j++; 
                }
                Console.WriteLine("The number " + num + " in base 10 (Decimal) is " + output + ".");
                Console.ReadLine();
            }
        }
    }
