    var str = "12345354987";
    var largestPotentialPalindrome =
        GetAllSubSequences(str).Where(s => IsRearrangableIntoPalindrome(s))
                               .OrderBy(s => s.Count())
                               .LastOrDefault();
    Console.WriteLine(new string(largestPotentialPalindrome.ToArray()));
