    using System;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine(Test("the quick brown [{#fox#}] jumps over the lazy dog."));
                Console.ReadLine();
            }
    
            public static string Test(string str)
            {
               
                if (string.IsNullOrEmpty(str))
                    return string.Empty;
    
    
                var result = System.Text.RegularExpressions.Regex.Replace(str, @".*\[{#", string.Empty, RegexOptions.Singleline);
                result = System.Text.RegularExpressions.Regex.Replace(result, @"\#}].*", string.Empty, RegexOptions.Singleline);
    
                return result;
    
            }
    
        }
    }
