        static string Reverse(string s)
        {
            if (s.Length >= 2)
                return Reverse(s.Substring(s.Length / 2)) + Reverse(s.Substring(0, s.Length / 2));
            else
                return s;
        }
        static bool IsPalindrome(string s)
        {
            if (s.Length <= 1)
                return true;
            if (s[0] == s[s.Length - 1] && IsPalindrome(s.Substring(1, s.Length-2)))
                return true;
            else
                return false;
        }
