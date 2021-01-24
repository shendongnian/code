    public static IEnumerable<string> SplitByLength(this string input, int groupSize)
    {
        // First split the input to the comma.
        // this will give us an array of all single numbers
        string[] numbers = input.Split(',');
        // Now loop over this array in groupSize blocks
        for (int index = 0; index < numbers.Length; index+=groupSize)
        {
            // Skip numbers from the starting position and 
            // take the following groupSize numbers, 
            // join them in a string comma separated and return 
            yield return string.Join(",", numbers.Skip(index).Take(groupSize));
        }
    }
