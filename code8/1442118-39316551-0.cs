    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                double[] input = {1.1,2.2,3.3,4.4};
                byte[] bArray = input.Select(x => BitConverter.GetBytes(x)).SelectMany(y => y).ToArray();
                List<double> output = new List<double>();
                for (int i = 0; i < bArray.Length; i += 8)
                {
                    output.Add(BitConverter.ToDouble(bArray,i));
                }
            }
        }
    }
