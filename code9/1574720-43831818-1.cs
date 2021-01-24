    private string GetLongestSubstring(string testString)
    {
        var longestSubstring = string.Empty;
        if (string.IsNullOrEmpty(testString))
        {
            return longestSubstring;
        }
    
        var rg = new Regex("[A-Z]");
        var currentSubstring = string.Empty;
        for (int i = 0; i < testString.Length; i++)
        {
            var currentChar = testString[i];
            var isValidChar = !char.IsDigit(currentChar);
            if (!isValidChar)
            {
                var newSubstring = currentSubstring;
                currentSubstring = string.Empty;
    
                var matches = rg.Match(newSubstring);
                var iscurrentSubstringContainsAtLeastOneCapitalLetter = matches.Success;
                if (iscurrentSubstringContainsAtLeastOneCapitalLetter)
                {
                    if (longestSubstring.Length < newSubstring.Length)
                    {
                        longestSubstring = newSubstring;
                    }
                }
                continue;
            }
    
            currentSubstring += currentChar.ToString();
        }
    
        if (currentSubstring.Length > longestSubstring.Length)
        {
            longestSubstring = currentSubstring;
        }
    
        return longestSubstring;
    }
   
