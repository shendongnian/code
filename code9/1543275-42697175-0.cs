    // Read in the complete file
    string fileContents = File.ReadAllText(@"pathToFile");
    // Split on all Whitespace (removing all empty entries)
    string[] numbers = fileContents.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
    
    // Process all the numbers
    int numberOfRows = int.Parse(numbers[0]);
    
    int[] pArray = new int[numberOfRows];
    int[] rArray = new int[numberOfRows];
    
    for (int i = 0; i < numberOfRows; i++)
    {
        pArray[i] = int.Parse(numbers[(i * 2) + 1]);
        rArray[i] = int.Parse(numbers[(i * 2) + 2]);
    }
