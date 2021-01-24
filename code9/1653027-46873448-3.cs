    public static char GetRandomCharacterFromString(string input)
    {
        // Do some basic null-checking
        if(input == null)
        {
            return char.MinValue; // Or throw an exception or, or, or...
        }
    
        var random = new Random();
        var inputAsCharArray = input.ToCharArray();
        var index = random.Next(0, input.Length);
    
        return inputAsCharArray[index];
    }
