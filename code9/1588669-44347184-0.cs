    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input = "SD46346\" && \"ADFF3342422\" && \"56-AS4566S";
                string pattern = @"\d{4}";  //exactly four digits in a row
                Match match = Regex.Match(input, pattern, RegexOptions.RightToLeft);
                string output = match.Value;
            }
        }
    }
