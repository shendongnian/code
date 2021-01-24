    var newString = string.Empty;
    
    for(int i = 0; i < input.Length; i++)
    {
        if(!Char.IsWhiteSpace(input[i]))
        {
            newString += input[i];
        }
    }
