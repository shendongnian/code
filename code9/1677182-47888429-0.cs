    string pattern = "emptystringpattern";
    string seperator = "||";
    string[] input = new string[] { string.Empty,"1" };
    for (int i = 0; i < input.Length; i++)
    {
        if (input[i] == string.Empty)
        {
            input[i] = pattern;
        }
    }
    
    string joinedInput = string.Join(seperator, input);
    var splits = joinedInput.Split(seperator.ToCharArray(),StringSplitOptions.RemoveEmptyEntries);
    
    for (int i = 0; i < splits.Length; i++)
    {
        if (splits[i] == pattern)
        {
            splits[i] = string.Empty;
        }
    }
