    using System;
    using System.Collections.Generic;
    using System.IO;
    using CsvHelper;
    
    namespace stack1
    {
        class Program
        {
            static void Main(string[] args)
            {
                //list of int
                var result = new List<int>();
                //total 
                int sum=0;
                int recordValue;
                using (TextReader fileReader = File.OpenText(@"C:\sample.csv"))
                {
                    var csv = new CsvReader(fileReader);
                    csv.Configuration.HasHeaderRecord = false;
                    csv.Configuration.TrimFields = false;
    
                    while (csv.Read())
                    {
                        for (var i = 0; csv.TryGetField(i, out recordValue); i++)
                        {
                            result.Add(recordValue);
                            sum += recordValue;
                        }
                    }
                }
                Console.WriteLine(sum);
                Console.ReadLine();
            }
        }
    }
