    using System;
    using System.Timers;
    namespace timer
    {
    class Program
    {
    static Timer timer = new Timer(1000); 
    static int i = 10; //this is for 10 seconds only change it as you will
    static void Main(string[] args)
    {            
        timer.Elapsed+=timer_Elapsed;
        timer.Start();
        Console.Read();
    }
    private static void timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        i--;
        Console.WriteLine("Time Remaining: " + i.ToString());
        if (i == 0) 
        {
            Console.WriteLine("Times up!");
            timer.Close();
            timer.Dispose();
        }
        GC.Collect();
    }
    }
    }
