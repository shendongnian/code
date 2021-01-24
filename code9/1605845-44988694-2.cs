    static void Main(string[] args)
    {
        double i, j = 0;
        Console.Write("Enter fnum: ");
        double.TryParse(Console.ReadLine(), out i);
        
        Console.Write("Enter snum: ");
        while (j == 0)
        {
            double.TryParse(Console.ReadLine(), out j);
    
            if(j==0)
                Console.WriteLine("Enter a number that is not 0");
        }
    
        Console.ReadLine();
        Console.WriteLine("Div result is {0}/{1}={2}", i, j, i / j);
    }
