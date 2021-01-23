    Console.Write("Please Enter The Cost, In Pennies, Of The Item You Have Purchased: ");
    inputcost = Console.ReadLine();
    bool result = false;
    while (!result)
    {
      result = checkNumber();
    }
    
    public static bool checkNumber()
    {
      if(inputcost < 1 || inputcost > 100)
      {
        Console.Write("Please Enter a valid value: ");
        inputcost = Console.ReadLine();
        return false;
      }
      else
        return true;
    } 
