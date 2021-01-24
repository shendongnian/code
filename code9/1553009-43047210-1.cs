    public static int GetNumDigitsWithoutToString(int forInput)
    {
        if (forInput == 0) return 1; // guard clause to prevent divide by zero error.
        int numDigits = 0;
        var x = (decimal) forInput;
    
        while (x >= 1)
        {
            numDigits++;
            x = x / 10;
        }
    
        return numDigits;
    }
