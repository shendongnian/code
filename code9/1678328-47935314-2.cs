    using System;
    using System.Timers;
    namespace ConsoleApplication1
    {
        class Program
        {
          
            static void Main(string[] args)
            {
                Program thisone = new Program();
                thisone.DoStuff();
                Console.Read();
            }
            public void DoStuff()
            {
                var intervalMs = 5000;
                Timer timer = new Timer(intervalMs);
                timer.Elapsed += new ElapsedEventHandler(DoStuffOnTimer);
                timer.Enabled = true;
            }
            private void DoStuffOnTimer(object source, ElapsedEventArgs e)
            {
                //do stuff
                Console.WriteLine("Tick!");
            }
        }
    }
