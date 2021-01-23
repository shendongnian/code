    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    public class Program
    {
        
        public static void Main(string[] args)
        {
            Parallel.Invoke(
                async () =>
                {
                    Console.WriteLine("Begin second task...");
                    TimeSpan eventTime = new TimeSpan(0,18,16,53,123); //set when run event (ex. 18:16:53.123)
                    DateTime endDate = DateTime.Today.Add(eventTime);
                    if(endDate<DateTime.Now) endDate = endDate.AddDays(1.0);
                    while (true)
                    {
                        TimeSpan duration = endDate.Subtract(DateTime.Now);
                        Console.WriteLine("looping at: {0:00} Days, {1:00} Hours, {2:00} Minutes, {3:00} Seconds, {4:00} Milliseconds", duration.Days, duration.Hours, duration.Minutes, duration.Seconds, duration.Milliseconds);
                        
                        if(duration.TotalMilliseconds <= 0.0)
                        { 
                            Console.WriteLine("It is time... {0}", DateTime.Now);
    
                            endDate = endDate.AddDays(1.0);
                            continue;
                        }
                        
                        int delay = (int)(duration.TotalMilliseconds/2);
                        await Task.Delay(delay>0?delay:0);
                    
                    }
                }
            );
            Thread.Sleep(6000);
        }
    }
               
