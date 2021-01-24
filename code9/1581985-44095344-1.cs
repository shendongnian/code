    bool valid = false;
    DateTime bday;
    while(!valid){
      Console.WriteLine("What is your birthday");
      string input = Console.ReadLine();
      
      if (DateTime.TryParse(input, out bday))
      { 
        Console.WriteLine("Invalid Date");
        valid = true;
      }
    }
