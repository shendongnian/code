    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    namespace DateAndMoney
    {
        public class InputNode
        {
            public DateTime dateTime;
            public string dollarAmount;
        }
        public class Program
        {
            public static void ReadFile(string filename)
            {
                InputNode inputNode = new InputNode();
                if (System.IO.File.Exists(filename))
                {
                    var reader = new StreamReader(File.OpenRead(filename));
                    while (!reader.EndOfStream)
                    {
                        var input = reader.ReadLine();
                        var values = input.Split(',');
                        try
                        {
                            inputNode.dateTime = Convert.ToDateTime(values[0]);
                            inputNode.dollarAmount = Convert.ToDouble(values[1]);
                        }
                        catch(Exception e)
                        {}
                    }
                }
            }
            public static void Main(string[] args)
            {
                string filename;
                Console.WriteLine("enter path and file name of input file");
                filename = Console.ReadLine();
                ReadFile(filename);
            }
        }
    }
