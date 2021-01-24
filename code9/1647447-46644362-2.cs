    public static string[] SplitString(string input, char delimiter)
    {
        List<String> parts = new List<String>();
        int start = 0;
        for(int i = 0; i < input.Length; i++)
        {
            if(input[i] == delimiter)
            {
                parts.Add(input.Substring(start, i - start));
                start = i + 1;
            }
        }
        parts.Add(input.Substring(start, input.Length - start));
        return parts.ToArray();
    }
