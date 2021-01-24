    static String Ištrinti(string eilutė)
    {
        // build a list from the split
        List<String> parts = new List<String>(eilutė.Split({' '}, StringSplitOptions.RemoveEmptyEntries));
        // create another list selecting only the strings with an even length
        List<String> partsEven = parts.Where(s => (s.Length % 2) == 0).ToList();
        // join the new list elements into a single string
        return String.Join(" ", partsEven);
    }
