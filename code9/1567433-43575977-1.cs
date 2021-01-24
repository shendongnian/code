        static Timer myTimer;
        public static int Main(string[] args)
        {
            // Do some stuff
            Console.WriteLine("Press any key to close this window.");
            //Hey, I just met you and this is crazy
            myTimer = new Timer(CallMeMaybe, null, 5000, 0);
            //so call me maybe
            Console.ReadKey();
            return 0;
        }
        //Instead of a tick, we have this
        private static void CallMeMaybe(object state)
        {
            //But here's my number
            Environment.Exit(0);
        }
