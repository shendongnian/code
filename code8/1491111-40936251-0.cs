    using System;
    using System.Timers;
    using System.Threading;
    
    namespace foo
    {
      class MainClass
      {
        public static void Main (string[] args)
        {
          int[] a=new int[100];
          a [99] = 0;
          int count = 0;
          System.Timers.Timer tmr = new System.Timers.Timer();
          tmr.Interval = 36000; // so that we can have a beer by the time we have our array
          tmr.Elapsed += async ( sender, e ) => 
            { if(count<a.Length) a[count]=count++; }
          ;
          tmr.Start ();
          while (a [99] < 99) {
            Thread.Sleep (10);
          }
          foreach(int i in a) {
            Console.WriteLine (i);
          }
    
        }
      }
    }
