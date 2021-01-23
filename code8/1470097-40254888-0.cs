        using System.Threading
    
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Now the following code will be repeated over and over");
        
                while(true)
                {
                    //////////////// FOLLOWING CODE /////////////////
                    /* the repeated code */
                    //////////////// END OF FOLLOWING CODE /////////////////
                  Thread.Sleep(5000);
                }   
            }
        }
