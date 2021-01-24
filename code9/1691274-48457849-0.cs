    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    
    namespace FirstLast
    {
        class Program
        {
            static void Main(string[] args)
            {
                String file = "C:\\samplec#programs\\FirstLast\\FirstLast\\bin\\Debug\\Test.csv";           
    
                using (StreamReader SR = new StreamReader(file))
                {
                    while (!SR.EndOfStream) //best way to do it
                    {
                        //read a line of our file and split it into its separate values
                        var CSValues = SR.ReadLine().Split(',');
                        String first = CSValues.First();
                        String last = CSValues.Last();
                        Console.WriteLine("First val: " + first + " , Last  val: " + last);                    
                    }    
                }
                Console.ReadLine();
            }
        }
    }
