      string[] MasterList = new string[] {
        "Askay", "Puram", "Raman", "Srinivasa",
        "Gopal", "Rajesh", "Anju", "Nagara",
      };
      Console.WriteLine("Enter your name: ");
      string YourName = Console.ReadLine();
      // StringComparer.OrdinalIgnoreCase if you want to ignore case
      // MasterList.Contains(YourName) if you want case sensitive 
      if (!MasterList.Contains(YourName, StringComparer.OrdinalIgnoreCase))
        Console.WriteLine("Your name is not among the list")
