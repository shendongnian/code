    static String Ištrinti(string eilutė)
    {
        // build a list from the split
        List<String> parts = new List<String>(eilutė.Split({' '}, StringSplitOptions.RemoveEmptyEntries));
        List<String> partsEven = parts.Where(s => (s.Length % 2) != 0);
        // join the remaining list elements into a single string
        return String.Join(" ", partsEven);
    }
