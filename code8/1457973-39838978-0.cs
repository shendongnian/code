    public string getInput() {
      while (true) {
        Console.WriteLine("Please enter your name. If you want to send the parcel: ");
        NameOfSender = Console.ReadLine();
        // if name is 
        //   1. Not empty
        //   2. Contains letters only
        // then return it; otherwise keep asking 
        if (!string.IsNullOrEmpty(this.NameOfSender) && 
             NameOfSender.All(c => char.IsLetter(c))) 
          return NameOfSender;
      } 
    } 
