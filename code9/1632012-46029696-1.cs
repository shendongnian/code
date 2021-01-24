    using System;
    
    namespace InsertTextFileSample
    {
        class Program
        {
    
            static void Main(string[] args)
            {
                string TextFile = Console.ReadLine();
                string path = @"C:\Users\Firzanah\Downloads\" + TextFile;
                string line;
                var fileReader =
                   new System.IO.StreamReader(path);
    
                Console.WriteLine("Contents of nvram.txt = /n");
                while ((line = fileReader.ReadLine()) != null)
                {
                    Console.WriteLine("\t" + line);
                }
    
                fileReader.Close();
                Console.ReadKey();
            }
        }
    }
