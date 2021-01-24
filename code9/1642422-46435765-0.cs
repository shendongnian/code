    using System;
    
    namespace FileFolder_46434099
    {
        class Program
        {
            static void Main(string[] args)
            {
                string incomingpath = @"C:\temp\3075";
                if (System.IO.Directory.Exists(incomingpath))
                {
                    Console.WriteLine("path is a directory");
                }
                else if (System.IO.File.Exists(incomingpath))
                {
                    Console.WriteLine("path is of a file");
                }
                Console.ReadLine();
            }
        }
    }
