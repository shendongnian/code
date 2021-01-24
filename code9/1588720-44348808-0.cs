      using System.Linq; 
      ...
      // Keep asking id... 
      while (true) {
        if (!Athletes.Any(athlete => athlete.ID == id)) 
          break; // ... until id is not found
        Console.WriteLine("ID already exists, please insert another ID!");
        Console.WriteLine();
        Console.Write("Id: ");
        id = Console.ReadLine(); 
        //TODO: validate id here 
     } 
