    using System;
    
    namespace WaitAsync
    {
        class Program
        {
    
            static void Main(string[] args)
            {
                bool ok = false;
     
                Console.Write("EnterTime (Seconds): ");
                int time = Convert.ToInt32(Console.ReadLine()) * 1000;
    
                while (ok != true)
                {
                    System.Threading.Thread.Sleep(time);
                    ok = true;
                    Console.WriteLine("Waiting Time Just Finished");
                }
                Console.ReadLine();
            }
        }
    }
