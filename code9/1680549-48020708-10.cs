    private static bool IsRearrangableIntoPalindrome(
        IEnumerable<char> characters) =>
        characters.Count() % 2 == 0 ?
            characters.GroupBy(c => c).All(g => g.Count() % 2 == 0):
            characters.GroupBy(c => c).Count(g => g.Count() != 0) == 1;
