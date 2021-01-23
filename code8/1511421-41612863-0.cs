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
                string[] filenames = { 
                   "TestCashFile_10_12-25-2016_D.csv", // - Shouldn't match
                   "TestCashFile_10_12-25-2016_D_A.csv.ap123", // - Should match and capture TestCashFile_10_12-25-2016_D_A.csv and 123
                   "TestCashFile_10_12-25-2016_D_A.csv.ap123.ds", // - Shouldn't match
                   "TestCashFile_10_12-25-2016_D.csv.ap2.ap1" //- Should match and capture TestCashFile_10_12-25-2016_D.csv.ap2 and 1
                                 };
                string renameSuffix = "ap";
                string pattern = @"(?'filename'.*)\." + renameSuffix + @"(?'suffix'\d*)$";
                foreach (string filename in filenames)
                {
                    Match match = Regex.Match(filename, pattern);
                    Console.WriteLine("Match : {0}, Filename : {1}, Suffix : {2}", match.Success ? "True" : "False", match.Groups["filename"].Value, match.Groups["suffix"].Value);
                }
                Console.ReadLine();
            }
        }
    }
