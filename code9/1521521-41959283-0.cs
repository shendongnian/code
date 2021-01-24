    private string Decrypt(string input)
    {
        const int shiftDelta = 10;
    
        var inputChars = input.ToCharArray();
        var outputChars = new char[inputChars.Length];
        
        for (var i = 0; i < outputChars.Length; i++)
        {
            // Perform character translation here
            outputChars[i] = (char)(inputChars[i] + shiftDelta); 
        }
    
        return outputChars.ToString();
    }
