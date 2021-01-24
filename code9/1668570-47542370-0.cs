    static String Ištrinti(string eilutė)
    {
        // build a list from the split
        List<String> parts = new List<String>(eilutė.Split({' '}, StringSplitOptions.RemoveEmptyEntries));
        // iterate the list starting from the bottom
        for (Int32 i = parts.Count - 1; i >= 0; --i)
        {
            // if the length of the current string is odd remove it
            if ((parts[i].Length % 2) != 0)
                parts.RemoveAt(i);
        }
        // join the remaining list elements into a single string
        return String.Join(" ", parts);
    }
