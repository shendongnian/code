        private string GetLongestSubstring(string testString)
        {
            var longestSubstring = string.Empty;
            if (string.IsNullOrEmpty(testString))
            {
                return longestSubstring;
            }
            var currentSubstring = string.Empty;
            for (int i = 0; i < testString.Length; i++)
            {
                var currentChar = testString[i];
                var isValidChar = !char.IsDigit(currentChar);
                if (!isValidChar)
                {
                    var newSubstring = currentSubstring;
                    currentSubstring = string.Empty;
                    var isValid = IsValidSubstring(newSubstring);
                    if (!isValid)
                    {
                        continue;
                    }
                    if (longestSubstring.Length >= newSubstring.Length)
                    {
                        continue;
                    }
                    longestSubstring = newSubstring;
                }
                currentSubstring += currentChar.ToString();
            }
            if (currentSubstring.Length > longestSubstring.Length)
            {
                longestSubstring = currentSubstring;
            }
            return longestSubstring;
        }
        private bool IsValidSubstring(string substring)
        {
            var rg = new Regex("[A-Z]");
            var matches = rg.Match(substring);
            var iscurrentSubstringContainsAtLeastOneCapitalLetter = matches.Success;
            if (!iscurrentSubstringContainsAtLeastOneCapitalLetter)
            {
                return false; 
            }
            return true;
        }
