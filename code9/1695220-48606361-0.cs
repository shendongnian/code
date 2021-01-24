    class a
    {
        private static int x;
        public static int X
        {
            get { return x; }
            set { //Call This area while oblect Creation }
         }
    }
    class Program
    {
        static void Main(string[] args)
        {
            a o = new a();
            a.X += 1;
            Console.WriteLine("Count is: " + a.X);
        }
    }
