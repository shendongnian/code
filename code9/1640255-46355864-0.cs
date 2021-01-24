       public static bool ExclusiveCharInCommon(string l, string r)
        {
            int CharactersInCommon(string f, string s)
            {
                if (f.Length == 0) return 0;
                return ((s.IndexOf(f[0]) != -1) ? 1 : 0) + CharactersInCommon(f.Substring(1), s);
            }
            return CharactersInCommon(l, r) == 1;
        }
