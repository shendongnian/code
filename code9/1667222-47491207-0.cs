        public static int LCIDFromLangName(string uKey)
        {
            uKey = uKey.ToLower();
            Dictionary<string, int> _dic;
            _dic = new Dictionary<string, int>();
            _dic.Add("de-de", 1031);
            _dic.Add("en-us", 1033);
            (and so on)
            int iRet = 0;
            bool b = _dic.TryGetValue(uKey, out iRet);
            if (!b)
            {
                iRet = 1033;
            }
            return iRet;
