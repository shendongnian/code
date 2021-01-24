    public static IEnumerable<string> SplitByLength(this string input, int length)
    {
        
        string[] numbers = input.Split(',');
        for (int index = 0; index < numbers.Length; index++)
        {
            yield return string.Join(",", numbers.Skip(index * length).Take(length));
        }
    }
