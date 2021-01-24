    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication4
    {
        class Program
        {
            static void Main(string[] args)
            {
                int [] OptionId=new int[]
                {
                   0, 1,4,7,3,1,37,9
                };
                Program p = new Program();
    
              int a= p. GeneratenewID(OptionId);
    
            }
    
    
            public int GeneratenewID(int[] OptionId)
            {
                Random ran = new Random(1);
                int number = 0;
                for (int j = 0; j < OptionId.Length ; j++)
                {
                   number =  ran.Next(OptionId.Length);
                    if (!OptionId.Contains(number)) 
                        break; 
                    else 
                        j--;
                }
                return number;
            }
        }
    }
