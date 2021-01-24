    static int a = 1;
    static int index
    {
        get
        {                
            return (a++);
        }
    }
    static void Main(string[] args)
    {
        if (index == 1 && index == 2 && index == 3)
            Console.WriteLine("Hurraa");
    }
