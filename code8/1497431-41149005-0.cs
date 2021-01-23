    Console.WriteLine("Please enter one or more sentences.");
    string text;    
    List<string> list = new List();
    while (true) 
    {
           text = Console.ReadLine();
           
          if (text.Length == 0)
              break;
          else
              list.Add(text);             
    }
