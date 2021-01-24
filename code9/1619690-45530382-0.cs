    public int checkValidNumber()
    {
        int a=0;
        if(!int.TryParse(Console.ReadLine(), out a))
        {
          Console.WriteLine("Please enter a valid number");
          return checkValidNumber();
        }
        return a;
    }
