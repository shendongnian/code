    List<String> allUserInputs = new List<String>();
    do
    {
       String newInput = Console.Read();
       if (!allUserInputs.Contains(newInput))
           allUserInputs.Add(newInput);
    } while(stopCriteria())
