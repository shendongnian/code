    public static int IndexExcludingValue(int[] test, int valueToFind, int valueToExclude)
    {
        return test.Where(z => z != valueToExclude)
            .Select((value, index) => new {value, index})
            .FirstOrDefault(z => z.value == valueToFind)?.index ?? -1; 
    }
