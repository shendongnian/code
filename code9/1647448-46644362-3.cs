    public static IEnumerable<string> SplitString(string input, char delimiter)
    {
        int start = 0;
        for(int i = 0; i < input.Length; i++)
        {
            if(input[i] == delimiter)
            {
                yield return input.Substring(start, i - start);
                start = i + 1;
            }
        }
        yield return input.Substring(start, input.Length - start);
    }
