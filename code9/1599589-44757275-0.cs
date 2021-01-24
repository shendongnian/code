    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace TestList
    {
        class Program
        {
            static void Main(string[] args)
            {
                double outcome = 1;
                List<double> list = new List<double>(new double[] { 1, 2, 6, 4, 6, 4, 9, 8, 3, 1 });
                //List<int> list = new List<int>(new int[] { 1, 2, 3 });
                for (int i = 0; i < list.Count; i++)
                {
                    for (int j = 0; j < list.Count; j++)
                    {
                        if (i == j)
                            continue;
                        outcome *= list[j];
                    }
                }
                Console.WriteLine(outcome);
                Console.WriteLine("Press any key to continue . . .");
                Console.ReadKey();
            }
        }
    }
