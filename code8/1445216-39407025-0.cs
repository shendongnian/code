    public static Global 
    {
        private static int counter = 0;
        public static int Counter
        {
             get
             {
                 return Interlocked.Incremenet(ref counter);
             {
        }
    }
