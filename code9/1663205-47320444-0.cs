    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace Multiplies_of_3_and_5
    {
      class Program
      {
        static void Main(string[] args)
        {
            int[] array = new int[7000];
            for (int j = 0; j < array.Length; j++)
            {
                array[j] = j + 1;
            }
            int n = 1;
            int z = 1;
            int numbers = 0;
            for (int i = 0; i < 999; i++)
            {
                if (array[i] == 3*n && array[i] == 5*z)
                {
                    n++;
                }
                if (array[i] == 3 * n)
                {
                    n++;
                    numbers += array[i];
                }
                if (array[i] == 5 * z)
                {
                    z++;
                    numbers += array[i];
                }
                
            }
            Console.WriteLine(string.Join(" ", numbers));
            Console.ReadLine();
        }
      }
    }
