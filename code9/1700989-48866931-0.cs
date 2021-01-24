    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json;
    using System.Net;
    using System.IO;
    using System.Threading;
    using System.Globalization;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string line;
                int rowCount = 0;
               
    
                using (StreamReader sr = new StreamReader(@"gg.txt"))
                {
                    var charLenght = int.Parse(sr.ReadLine().Split('=')[1]);
                    var charHeight = int.Parse(sr.ReadLine().Split('=')[1]);
                    var whatToPrint = sr.ReadLine().Split('=')[1].Trim();
                    //foreach (var letter in whatToPrint)
                    for (int i = 0; i < whatToPrint.Length; i++)
                       
                    {
                        int pos = whatToPrint[i] - 'A';
    
                        for (int j = 0; j < charHeight; j++)
                        {
                            
                            line = sr.ReadLine();
                            Console.SetCursorPosition(charLenght * i, j);
                            int left = Console.CursorLeft, top = Console.CursorTop; left = left; top = top;
                            if (whatToPrint[i] == (char)32)
                                break;
    
                            else
                                Console.WriteLine(line.Substring(charLenght * pos, charLenght)); 
    
                          
                        }
                        // back to start of the text file and skip the first 3 rows
                        sr.DiscardBufferedData();
                        sr.BaseStream.Seek(0, SeekOrigin.Begin);
                        
                       
                        for (int l = 0; l < 3; l++)
                        {
                            sr.ReadLine();
                        }
                        
                    }
                }
    
                Console.ReadLine();
                
            }
        }
