    private static bool IsRearrangableIntoPalindrome(
        this IEnumerable<char> characters) 
        =>  characters.Count() % 2 == 0 ?
            //all even
            characters.GroupBy(c => c)
                      .All(g => g.Count() % 2 == 0):
            //one odd
            characters.GroupBy(c => c)
                      .Count(g => g.Count() % 2 != 0) == 1; 
