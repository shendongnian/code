    public double Radius
    {
        get { return radius; }
        set
        {
            radius = value;
        }
    }
    public void DrawCircle()
    {
        // this tells you a developer that the method is being misused
        if (radius <= 0 )
           throw new ArgumentExcetion("Radius cant be less or equal to 0");
        ...
    }
    static void Main(string[] args)
    {
        Circle circle = new Circle();
        Info info = new Info(circle);
        int number = Convert.ToInt32(Console.ReadLine());
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
