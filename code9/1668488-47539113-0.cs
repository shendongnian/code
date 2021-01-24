    private static int[] SortRangeReverse(int[] input, int startRange, int endRange)
    {
        // Argument validation - decide what you want to do if the args aren't what you expect
        if (input == null || input.Length < 2) return input;
        if (endRange <= startRange) return input;
        if (startRange < 0) startRange = 0;
        if (endRange > input.Length - 1) endRange = input.Length - 1;
        // The actual "meat" of the original answer in a more generic form:
        return
            input.Take(startRange)
                .Concat(input.Skip(startRange).Take(endRange + 1 - startRange).Reverse()
                .Concat(input.Skip(endRange + 1)))
                .ToArray();
    }
