    using System;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication1
    {
    public class Program
    {
        public static void Main()
        {
            //First part
            string first = "i:0#.f|membership|sdp950452@abctechnologies.com";
            string second = "i:0#.f|membership|tss954652@abctechnologies.com";
            string pattern = @"\|[A-Za-z0-9]+\@";
            Regex reg = new Regex(pattern);
            Match m1 = reg.Match(first);
            Match m2 = reg.Match(second);
            string result1 = m1.Value.Replace("|",string.Empty).Replace("@",string.Empty);
            string result2 = m2.Value.Replace("|", string.Empty).Replace("@", string.Empty);
            Console.WriteLine(result1);
            Console.WriteLine(result2);
            //Second part
            string inputString = "Pawar, Jaywardhan";
            string a = inputString.ToLower(); 
            var b = a.Split(' ');
            var result3 = b[1] + " " + b[0].Replace(",",string.Empty); 
        }
    }
    }
