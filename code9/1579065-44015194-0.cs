    using System;
    using System.Threading;
    public class EntryPoint
    {
        static private int counter = 0;
        static private object theLock = new Object();
        static object obj = new object();
        static private void count()
        {
            {
                    for (int i = 0; i < 10; i++)
                {
                    lock (theLock)
                    {
                        Console.WriteLine("Count {0} Thread{1}",
                        counter++, Thread.CurrentThread.GetHashCode());
                         if (counter>=10) 
                        Monitor.Pulse(theLock);
                        Monitor.Wait(theLock);  }  }}
        }
        static void Main()
        {
            Thread[] tr = new Thread[10];
            for (int i = 0; i < 10; i++)
            {
                tr[i] = new Thread(new ThreadStart(count));
                tr[i].Start();
            }
    
        }
    } 
