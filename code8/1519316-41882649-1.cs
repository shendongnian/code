    string[] items = GetGroceryList();
    if (items.Length > 0) {
      Console.WriteLine("Thanks for the list, we will now ask you for the cost of each item");
      foreach (string item in items) {
        Console.WriteLine(item);
        // get the cost of the item????
      }
    }
    else {
      Console.WriteLine("Your list is blank");
    }
    Console.ReadLine();
