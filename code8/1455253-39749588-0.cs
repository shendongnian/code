    using System;
    using System.IO;
    
    namespace CSVExample
    {
        class Program
        {
            static void Main(string[] args)
            {
                string data = "Col1, Col2, Col2";
                string filePath = @"File.csv";
                File.WriteAllText(filePath, data);
                string dataFromRead = File.ReadAllText(filePath);
                Console.WriteLine(dataFromRead);
            }
        }
    }
