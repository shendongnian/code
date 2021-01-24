    public void output()
    {
        if (marks >= 75)
        {
            Console.WriteLine("Merit");
        }
        else if (marks < 55)
        {
            Console.WriteLine("Pass");
        }
        else if (marks < 65)
        {
            Console.WriteLine("Credit");
        }
        else if (marks < 75)
        {
            Console.WriteLine("Distiction");
        }
        else Console.WriteLine("Fail");
    }
