    string sequenceSelector = Console.ReadLine();
    int intValue;
    if(int.TryParse(sequenceSelector, out intValue))
    {
        if (intValue <= 0)
        {
            throw new IndexOutOfRangeException();
        }
        String outputString = "[" + sequenceSelector + "]: ";
        for (int i = 0; i < intValue; i++)
        {
            outputString = outputString + fibonacciSequence.GetValue(i) + ", "; // you can omit the call to ToString, it´s called implictely by the runtime
        }
        Console.WriteLine(outputString);
        return intValue;
    }
    else if(sequenceSelector.ToUpper().Contains("STOP")) { ... }
