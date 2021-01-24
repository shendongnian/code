    private static bool IsRearrangableIntoPalindrome(
        IEnumerable<char> characters)
    {
        Debug.Assert(characters != null);
        var chars = characters.ToList();
        if (chars.Count % 2 == 0)
        {
            return characters.GroupBy(c => c)
                             .All(g => g.Count() % 2 == 0);
        }
        else
        {
            return chars.GroupBy(c => c)
                        .Select(g => g.Count() % 2)
                        .Count(c => c != 0) == 1; 
        }
    }
