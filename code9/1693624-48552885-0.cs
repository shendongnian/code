    using System;
    using System.Text.RegularExpressions;
    
    public class Program
    {
        public static void Main(string[] args)
        {
            var s = "w o r d 1   w o r d 2   w o r d 3   w o r d 4  ";
    
            Regex re = new Regex("( (?! ))");
            s = re.Replace(s, "").Replace("  ", " ");
            Console.WriteLine(s);
            Console.ReadLine();
        }
    }
