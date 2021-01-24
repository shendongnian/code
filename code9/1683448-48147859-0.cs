    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication19
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                StreamWriter writer = new StreamWriter(FILENAME);
                List<List<string>> inputs = new List<List<string>>() {
                     new List<string>() {"Template ID", "Node Tree", "Row Number", "Column Name", "Error Type"," Error"},
                     new List<string>() {"Description 21843 ", "VOUCHER", "16428000","","Error", "Parent Name is not Correct"}
                };
                foreach (List<string> input in inputs)
                {
                    writer.WriteLine(string.Join("\t|", input));
                }
                writer.Flush();
                writer.Close();
            }
        }
    }
