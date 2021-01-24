    class a
    {
        private static int x;
        public static int X
        {
            get { return x; }
            set { x = value;}
        }
        public static a incrementX()
        {
            X++;
            return new a();
        }
    }
