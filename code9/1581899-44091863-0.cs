<!-- language: lang-css -
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                StreamReader reader = new StreamReader(FILENAME);
                string inputline = "";
                List<List<decimal>> data = new List<List<decimal>>();
                int columns = 0;
                int dataPoints = 0;
                Boolean firstRow = true;
                string[] inputArray;
                while ((inputline = reader.ReadLine()) != null)
                {
                    inputline = inputline.Trim();
                    if (inputline.Length > 0)
                    {
                        inputArray = inputline.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                        if (firstRow == true)
                        {
                            firstRow = false;
                            dataPoints = int.Parse(inputArray[0]);
                            columns = int.Parse(inputArray[1]);
                        }
                        else
                        {
                            List<decimal> inputDecimal = inputArray.Select(x => decimal.Parse(x)).ToList();
                            data.Add(inputDecimal);
                        }
                    }
                }
            }
        }
    }
