    class Program
    {
        class TimerTest
        {
            private Timer timer1;
    
            private void Callback1(object state)
            {
                Console.WriteLine("Callback1");
            }
            private void Callback2(object state)
            {
                Console.WriteLine("Callback2");
            }
    
            public TimerTest()
            {
                // Class scoped timer
                timer1 = new Timer(Callback1, "", TimeSpan.FromSeconds(0.1), TimeSpan.FromSeconds(0.20));
    
                // Function scoped Timer (force displose with using)
                using (Timer timer2 = new Timer(Callback2, "", TimeSpan.FromSeconds(0.1), TimeSpan.FromSeconds(0.20)))
                {
                    // Give some time for timer2 callbacks
                    Thread.Sleep(500);
                }
            }
        }
    
    
        static void Main(string[] args)
        {
            TimerTest test = new TimerTest();
    
            while (true) Thread.Sleep(1000);
        }
    }
