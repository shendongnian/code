    private static string StringDouble(string input)
    {
        var intSplitResult =
            input.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(str =>
                    {
                        int value;
                        bool success = int.TryParse(str, out value);
                        return new { value, success };
                    })
                    .Where(pair => pair.success)
                    .Select(pair => pair.value);
        if (intSplitResult.Count() != 2)
        {
            throw new ArgumentException(
                       $"Invalid Input: [{input}]. Do not contains the right number of number!"
                       , nameof(input));
        }
        return string.Join(".", intSplitResult);
    }
