    string sequenceSelector = Console.ReadLine();
    int intValue;
    if(int.TryParse(sequenceSelector, out intValue))
    {
        if (intValue <= 0)
        {
            throw new IndexOutOfRangeException();
        }
        String outputString = "[" + intValue.ToString() + "]: ";
        for (int i = 0; i < sequenceSelector; i++)
        {
            outputString = outputString + fibonacciSequence.GetValue(i).ToString() + ", ";
        }
        Console.WriteLine(outputString);
        return intValue;
    }
    else if(sequenceSelector.ToUpper().Contains("STOP")) { ... }
