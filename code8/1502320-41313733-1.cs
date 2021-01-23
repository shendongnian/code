    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Select_specific_lines_in_an_array
    {
        class Program
        {
            static void Main(string[] args)
            {
                string line = "";
                int count = 0;
    
                List<List<string>> testlist = new List<List<string>>();
                List<string> templist = new List<string>(); 
    
                System.IO.StreamReader file = new System.IO.StreamReader("inputfile.txt");
                while ((line = file.ReadLine()) != null)
                {
                    if (line != "line I don't want to select")
                    {
                        Console.WriteLine(line);
                        templist.Add(line);
                        if (templist.Count == 2)
                        {
                            testlist.Add(templist);
                            templist = new List<string>();
                        }
                    }
                    count = count + 1;
                }
                file.Close();
                Console.ReadKey();
            }
        }
    }
