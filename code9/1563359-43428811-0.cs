    do{
       Console.Write("Please enter something ");
       input = Console.ReadLine(); 
       collection.Add(input);
      } while (!String.IsNullOrEmpty(input));
