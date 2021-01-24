    using System;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string str = "XXXXX-XXXXX-XXXXX";
                Regex re = new Regex(@"^[^-]*-[^-]*-[^-]*$");
                Console.Out.WriteLine(re.Match(str).Success);
            }
        }
    }
