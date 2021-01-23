       static void Main(string[] args)
    {
        int num = 0; 
        TimerCallback tm = new TimerCallback(Count);
        Timer timer = new Timer(tm, num, 0, 2000);//where the 4-th number is interval in milliseconds
 
        Console.ReadLine();
    }
    public static void Count(object obj)
    {
        int x = (int)obj;
        for (int i = 1; i < 9; i++, x++)
        {
            Console.WriteLine("{0}", x*i);      
        }
    }
