    static void Main(string[] args)
        {
            System.Threading.Timer timer = new Timer(new TimerCallback(CheckUsage), null, 0, 1000);
            //exit and dispose timer somehow
        }
        static void CheckUsage(object state)
        {
            //Check usage here
        }
