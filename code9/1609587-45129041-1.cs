    using System;
    using System.Timers;
    namespace timer
    {
    class Program
    {
    static Timer timer = new Timer(1000); 
    static int i;
    static void Main(string[] args)
    {            
        timer.Elapsed+=timer_Elapsed;
        Console.WriteLine("Input Number:");
        i=Convert.ToInt32(Console.ReadLine());
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
