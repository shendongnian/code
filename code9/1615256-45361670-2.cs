    using System;
    using System.Text.RegularExpressions;
    
    namespace regex
    {
        class Program
        {
            static void Main(string[] args)
            {
                var text = @"something up here
    void anotherfunc(int x)
    {
    
    }
    
    void function1 (void)
    {
         Some junk here();
         Other Junk here
         {
             Blah blah blah
         }
    }
    
    int main()
    {
    }";
    
                var replacement = @"function1 (void)
        Something else here
    }";
    
                Console.Out.WriteLine(Regex.Replace(text, @"function1(?:.|\n)*?^}", replacement, RegexOptions.Multiline));
            }
        }
    }
