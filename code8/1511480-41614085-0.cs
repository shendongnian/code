    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication42
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input1 = 
                    "Subj1\n" +
                    "Subj3\n" +
                    "Subj5\n" +
                    "Subj7\n";
                string input2 =
                     "Subj1 (1)\n" +
                     "Subj5 (6)\n" +
                     "Subj4 (2)\n" +
                     "Subj2 (8)\n";
                
                string[] stringArray= (input1 + input2).Split(new char[] {'\n'}, StringSplitOptions.RemoveEmptyEntries);
                var groups = stringArray.GroupBy(x => x.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0]);
                string output = string.Join("\n", groups.Select(x => x.OrderByDescending(y => y.Length).FirstOrDefault()));
            }
        }
    }
