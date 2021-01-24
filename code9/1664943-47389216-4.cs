    public static void Main() {
      List<string> items = new List<string>() {
        "User",
        "User Groups",
        "User Activity Log",
        "Report Designer",
        "Report Activity Log",
      }
    
      while (true) {
        Console.WriteLine("Please type in the first letter of item you are looking for:");
        Console.WriteLine("Prease press enter (i.e. type an empty string) to quit"); 
    
        string mySearchString = Console.ReadLine();
    
        if (string.IsNullOrEmpty(mySearchString)) 
          break;
    
        foreach (var item in items.Where(r => r.IndexOf(mySearchString) == 0))
          Console.WriteLine(item);
    
        Console.WriteLine();
      }
    }
