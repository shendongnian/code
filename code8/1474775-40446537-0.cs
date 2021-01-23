    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    public class Program
    {
        
        public static void Main(string[] args)
        {
            Parallel.Invoke(
                () =>{Console.WriteLine("Begin first task...");},
                async () =>
                {
                    Console.WriteLine("Begin second task...");
                    DateTime startDate = DateTime.Now;
                    while (true)
                    {
                        TimeSpan duration = DateTime.Now.Subtract(startDate);
                        Console.WriteLine("looping at: {0:00} Days, {1:00} Hours, {2:00} Minutes, {3:00} Seconds, {4:00} Milliseconds", 
                                          duration.Days, duration.Hours, duration.Minutes, duration.Seconds, duration.Milliseconds);
    
                        int delay = (int)(DateTime.Today.AddDays(1.0).Subtract(DateTime.Now).TotalMilliseconds/2);
                        await Task.Delay(delay>0?delay:0);
    
                        if(duration.Days >= 1) 
                        { 
                            
                            Console.WriteLine("It is time... midnight is {0}", DateTime.Now);
    
                            startDate = DateTime.Now;
                        }
                    
                    }
                }
            );
        }
    }
           
