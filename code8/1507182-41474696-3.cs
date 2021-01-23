        public static unsafe int GetNumber(string s)
        {
            int number;
            if (int.TryParse(s, out number))
                return number;
            int value = 0;
            fixed (char* pString = s)
            {
                var pChar = pString;
                for (int i = 0; i != s.Length; i++, pChar++)
                {
                    if (*pChar < '\u0030' || *pChar > '\u0039') continue;
                    value = value * 10 + *pChar - '\u0030';
                }
            }
            return value;
        } 
