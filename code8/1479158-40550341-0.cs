      int realPin = 1111;
    
      while (true) {
        int pin; 
    
        do {
          Console.WriteLine("Please enter a 4 numbers please: ");
        }
        while (!int.TryParse(Console.ReadLine(), out pin)); 
       
        if (pin == realPin)
          break;
    
        Console.WriteLine("Wrong Password");
      }
      // unlocked
