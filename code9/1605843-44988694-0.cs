    static void Main(string[] args)
    {
        double i, j;
        Console.WriteLine("Enter fnum");
        int.TryParse(Console.ReadLine(), out i);
        
        Console.WriteLine("Enter snum");
        while (true)
        {
            int.TryParse(Console.ReadLine(), out k);
    
            if(j!=0)
                break;
            else
                Console.WriteLine("Enter a number that is not 0");
        }
    
        Console.ReadLine();
        Console.WriteLine("Div result is {0}/{1}={2}", i, j, i / j);
    }
