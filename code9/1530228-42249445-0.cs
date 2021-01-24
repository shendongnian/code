    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace NumberofOnes
    {
        public class Program
        {
            static void Main(string[] args)
            {
                int m, count = 0;
                Console.WriteLine("Enter the Limit : ");
                m = int.Parse(Console.ReadLine());
                List<int> a = new List<int>();
               
                Console.WriteLine("Enter the Numbers :");
                for (int i = 0; i < m; i++)
                {
                    a.Add( Convert.ToInt32(Console.ReadLine()));
                }
                foreach (int o in a)
                {
                    if (o == 1)
                    {
                        count++;
                    }
                }
                Console.WriteLine("Number of 1's in the Entered Number : " + count);
    
                Console.ReadLine();
    
            }
        }
    }
 
