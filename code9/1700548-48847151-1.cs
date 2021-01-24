    static void Main(string[] args)
    {
        Circle circle = new Circle();
        Info info = new Info(circle);
        int number = Convert.ToInt32(Console.ReadLine());
        while(number <= 0)
        {
             Console.WriteLine("Invalid input detected");
        }
        circle.Radius = number;
        try
        {
        }
        catch(ArgumentException ex)
        {
            // log or alert the user
            // Console.WriteLine(ex.Message);
        }
    }
