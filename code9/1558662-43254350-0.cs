        public static void Main(string[] args)
        {
            char c = 'a';
            object o1 = c += (char)1;
            object o2 = c + (char)1;
            WriteLine("o1 " + o1.GetType());
            WriteLine("o2 " + o2.GetType());
         }
