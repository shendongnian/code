        static Timer myTimer;
    
        public static int Main(string[] args)
        {
            // Do some stuff
            Console.WriteLine("Press any key to close this window.");
    
            //CallMeMaybe = Callback event
            //Null = unimportant
            //5000 = How long thread waits to start
            //0 = Period timer ticks. This can be 0 because it closes once it starts at 5000
            myTimer = new Timer(CallMeMaybe, null, 5000, 0);
    
            //Waits for user key
            Console.ReadKey();
    
            return 0;
        }
    
        //Instead of a tick, we have this
        private static void CallMeMaybe(object state)
        {
            Environment.Exit(0);
        }
