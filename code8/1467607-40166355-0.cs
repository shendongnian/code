    string inputcost;
    string inputmoney;
    int validcost = 0;
    int validmoney = 0;
 
    Console.Write("Please Enter The Cost, In Pennies, Of The Item You Have Purchased: ");
    inputcost = Console.ReadLine();
    // only accept integers
    while (!int.TryParse(inputcost, out validcost))
    {
      Console.Write("Please Enter An Integer Value: ");
      inputcost = Console.ReadLine();
    }
    // valid integer input in variable validcost 
    bool done = false;
    while (!done)
    {
      Console.Write("Enter an integer between 1 and 100: ");
      inputmoney = Console.ReadLine();
      if (int.TryParse(inputmoney, out validmoney))
      {
        if (validmoney > 0 && validmoney < 101)
        {
          done = true;
        }
        else
        {
          Console.WriteLine("Invalid input: " + inputmoney);
        }
      }
      else
      {
        Console.WriteLine("Invalid input: " + inputmoney);
      }
    }
      //validcost is an integer and validmoney is an integer between 1 and 100
      Console.WriteLine("validcost: " + validcost + " validmoney: " + validmoney);
      Console.ReadKey();
   
