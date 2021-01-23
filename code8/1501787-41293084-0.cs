    public string StringToASCII(string input)
    {
        var sb = new StringBuilder();
        for (int i = 0; i < input.Length; i++)
        {
            if (Char.IsLetterOrDigit(input[i]) || input[i] == ' ')
            {
                sb.Append(input[i]);
            }
        }
        return sb.ToString();
    }
