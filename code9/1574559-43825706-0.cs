    class List
    {
        static Random r1 = new Random();
        private int[] tabb;
    
        public List(int b)
        {
            tabb = new int[b];
            for (int i = 0; i < b; i++)
                tabb[i] = r1.Next(0, 100);
        }
        // This constructor calls the first one with a random number between 1 and 10
        public List(): this(r1.Next(1,11))
        { }
    
        public override string ToString()
        {
            return string.Join(",", tabb);
        }
    }
