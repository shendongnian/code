    private static bool IsRearrangableIntoPalindrome(
        IEnumerable<char> characters)
    {
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
                        .OrderByDescending(c => c)
                        .Skip(1)
                        .All(c => c == 0);
        }
    }
