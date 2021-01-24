    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.VisualBasic;
    
    namespace SandBox
    {
        class Program
        {
    
            static void Main(string[] args)
            {
                List<string> outputStrings = new List<string>();
                string path = @"C:\Users\oa971d\Desktop\textSample.txt";
    
                using (Microsoft.VisualBasic.FileIO.TextFieldParser parser =
                    new Microsoft.VisualBasic.FileIO.TextFieldParser(path))
                {
                    parser.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;
                    parser.SetDelimiters(":"); //.csv
                                               //parser.SetDelimiters("\t"); //tab delimited .txt
                    
                  while(!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();
                        if(fields.Length>1)
                            outputStrings.Add(fields[1]);
                    }        
                }
                foreach(string s in outputStrings)
                { Console.WriteLine(s); }
                Console.ReadLine();
            }
        }
    }
