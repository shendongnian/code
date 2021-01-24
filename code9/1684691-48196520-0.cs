        static bool SindAlleZeichenGleich(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != s[0])
                {
                    return false;
                }
            }
            if(s == "")
            {
                return false;
            }
            return true;
        }
 
 
