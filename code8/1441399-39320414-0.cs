    using System;
    using System.Threading;
    
    class TimerExampleState {
        public int counter = 0;
        public Timer tmr;
    }
    
    class App {
       public static void Main() {
        TimerExampleState s = new TimerExampleState();
    
        // Create the delegate that invokes methods for the timer.
        TimerCallback timerDelegate = new TimerCallback(CheckStatus);
    
        // Create a timer that waits one second, then invokes every second.
        Timer timer = new Timer(timerDelegate, s, 1000, 1000);
        
        // Keep a handle to the timer, so it can be disposed.
        s.tmr = timer;
    
        // The main thread does nothing until the timer is disposed.
        while (s.tmr != null)
            Thread.Sleep(0);
        Console.WriteLine("Timer example done.");
       }
       // The following method is called by the timer's delegate.
    
       static void CheckStatus(Object state) {
        TimerExampleState s = (TimerExampleState) state;
        s.counter++;
              Console.WriteLine("{0} Checking Status {1}.",DateTime.Now.TimeOfDay, s.counter);
            if (s.counter == 5) {
            // Shorten the period. Wait 10 seconds to restart the timer.
            (s.tmr).Change(10000,100);
            Console.WriteLine("changed...");
        }
            if (s.counter == 10) {
            Console.WriteLine("disposing of timer...");
            s.tmr.Dispose();
            s.tmr = null;
        }
       }
    }
