    private static int ShowMenu ()
    {
      int iChoice = 0;
      //display the choices
      Console.WriteLine("Vending Machine");
      Console.WriteLine("1 - Buy chocbars");
      Console.WriteLine("2 - Buy crisps");
      Console.WriteLine("3 - Buy sweets");
      // get the users choice
      Console.Write("Enter your choice: ");
      iChoice = Convert.ToInt32(Console.ReadLine());
      return iChoice;
    }
