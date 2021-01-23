    public static class StringExtensions
    {
        public static string GetStartChars(this string s)
        {
            s = s.TrimStart();
            var result = string.Empty;
            if (!string.IsNullOrEmpty(s))
            {
                foreach (var letter in s.ToCharArray())
                {
                    if (char.IsLetter(letter))
                    {
                        result += letter;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return result;
        }
    }
