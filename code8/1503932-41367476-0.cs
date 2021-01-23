    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace most_frequent_int
    {
    class Program
    {
        static void Main(string[] args)
        {
         halfCheck(new int[] {1,1,2,3});
        }
    
        static void halfCheck(int[] checkArray)
        {
            int fHalf = 0; 
            int sHalf=0;
    
            //even method
            if (checkArray.Length % 2 == 0) 
            {               
                for (int i= 0;i<checkArray.Length/2;i++)//check first half even
                {
                    fHalf = fHalf + checkArray[i];
                }
    
            for (int i=checkArray.Length - 1;i>checkArray.Length/2;i--)
                {
                    sHalf = sHalf + checkArray[i];
                    Console.WriteLine(sHalf);
                }
    
                if (fHalf > sHalf)
                {
                    Console.WriteLine("The first half is bigger");
                }
                else
                {
                    Console.WriteLine("The second half is bigger");
                }
                Console.ReadLine();
    
            }
    
            //odd method
            else
            {
                Console.WriteLine("odd");
            }
    
        }
    
    }
    }
