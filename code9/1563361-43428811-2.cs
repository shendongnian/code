    do{
       Console.Write("Please enter something ");
       input = Console.ReadLine(); 
       if (inputIsNotEmpty(input)) collection.Add(input);
      } while (inputIsNotEmpty(input);
    ...
    bool inputIsNotEmpty(string input) => !String.IsNullOrEmpty(input);
