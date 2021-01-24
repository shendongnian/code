        static void Main()
        {
            System.Timers.Timer timer = new System.Timers.Timer(300000);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
            //DO WHATEVER YOU WANT HERE
        }
        private static void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Application.Exit();
        }
