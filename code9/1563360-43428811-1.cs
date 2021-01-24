    do{
       Console.Write("Please enter something ");
       input = Console.ReadLine(); 
       if (isValidInput(input)) collection.Add(input);
      } while (isValidInput(input);
    ...
    static bool isValidInput(string input) => !String.IsNullOrEmpty(input);
