    List<String> allUserInputs = new List<String>();
    int counter = 0;
    int maxIterations = 100;
    do
    {
       counter++;
       String newInput = Console.Read();
       if (!allUserInputs.Contains(newInput))
           allUserInputs.Add(newInput);
       else
           Console.WriteLine("\nYour input already exists. Please try again.\n")
    } while(counter <= maxIterations)
