    //Rextester.Program.Main is the entry point for your code. Don't change it.
    //Compiler version 4.0.30319.17929 for Microsoft (R) .NET Framework 4.5
    using System;
    using System.Text.RegularExpressions;
    using System.Globalization;
    namespace Rextester
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                string str = "4.2 43 f-2.1-1k 4. a.1 5asd11 54 -1.99";
                Regex regex = new Regex(@"(?<=^| )([-+]?\d+\.?(?:\d+)?)(?= |$)");            
                Match m;
                m = regex.Match(str);
                while (m.Success)
                {
                     try
                    {
                        //buffor[index] = float.Parse(m.ToString());
                        //index++;
                        Console.WriteLine(float.Parse(m.ToString(), CultureInfo.InvariantCulture));
                    }
                    catch (FormatException ex) { }
                    m = m.NextMatch();             
                }
            }
        }
    }
