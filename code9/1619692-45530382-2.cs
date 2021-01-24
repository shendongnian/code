    public int checkValidNumber()
    {
        int a=0;
        while(!int.TryParse(Console.ReadLine(), out a))
        {
          Console.WriteLine("Please enter a valid number");
        }
        return a;
    }
