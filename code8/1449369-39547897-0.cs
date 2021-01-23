       class main
    {
        static long afield = 123;
    
        public static main()
        {
            Console.WriteLine(afield);
        }
    
       public main()
        {
            afield = 1000;
            Console.WriteLine(afield);
        }
    }
    
    static void Main(String[] args)
    {
        main obj = new main();
    }
