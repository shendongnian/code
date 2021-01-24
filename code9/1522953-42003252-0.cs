    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"lista.txt";
            static void Main(string[] args)
            {
                StreamReader reader = new StreamReader(FILENAME);
                int lineCount = 0;
                string inputline = "";
                do while((inputline = reader.ReadLine()) != null)
                {
                    if(++lineCount == 13)
                    {
                        string[] inputArray = inputline.Trim().Split(new char[] {' ','\t'},StringSplitOptions.RemoveEmptyEntries);
                        Console.WriteLine("Exchange Rate : '{0}'", inputArray[2]);
                        break;
                    }
                }
            }
        }
    }
