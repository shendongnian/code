        using System;
        using System.Collections.Generic;
        using System.IO;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;
        
        namespace _07___ReadTextFileWhile
        {
            class Program
            {
                static void Main(string[] args)
                {
                    StreamReader myReader = new StreamReader("DATA10.txt");
        
                    string line = "";
        
                    while (line != null)
                    {
                        line = myReader.ReadLine();
                        if (line != null)
                            Console.WriteLine(line);
                    }
        
                    myReader.Close();
                    Console.ReadKey();
        
                }
            }
        }
