    List<string> names = new List<string>();
    
    while (true) {
      string line = Console.ReadLine();
    
      if (string.IsNullOrEmpty(line)) // break on Enter - i.e. on empty line
        break;
    
      names.Add(line); // otherwise add into the list
    }
