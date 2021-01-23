    using System;
    using System.Linq;
    namespace Demo
    {
        class Program
        {
            static void Main()
            {
                Console.WriteLine(demo(75));
                Console.WriteLine(demo(96));
                Console.WriteLine(demo(79));
                Console.WriteLine(demo(97));
                Console.WriteLine(demo(67849));
                Console.WriteLine(demo(59587));
                Console.WriteLine(demo(873579));
                Console.WriteLine(demo(135));
            }
            static string demo(int number)
            {
                string result = new string(
                    number.ToString().Where(digit => digit == '7' || digit == '9')
                    .Select(digit => (digit == '7') ? 'S' : 'N' )
                    .ToArray());
                return result.Length > 0 ? result : number.ToString();
            }
        }
    }
