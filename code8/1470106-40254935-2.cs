    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace recurssiveWithThread
    {
        class Program
        {
    
            static void Main(string[] args)
            {
             
                RecWork();     
            }
            public static int i = 0;
            public static void RecWork()
            {
                // Do the things whatever you needed here 
                
                i++;
                Console.WriteLine(i);
                //Thread to make the process to sleep for sometimes
                Thread.Sleep(5000);
    
                //Call your function here
                RecWork();
            }           
        }
    }
