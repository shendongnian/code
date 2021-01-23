        string removeLetters(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (IsEnglishLetter(c))
                {
                    s = s.Remove(i, 1);
                }
            }
            return s;
        }
        bool IsEnglishLetter(char c)
        {
            return (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z');
        }
