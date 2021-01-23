    public struct CappedString
    {
        int Max_Length;
        string val;
    
        public CappedString(string str, int maxLength = 20)
        {
            Max_Length = maxLength;
            val = (string.IsNullOrEmpty(str)) ? "" :
                  (str.Length <= Max_Length) ? str : str.Substring(0, Max_Length);
        }
        // From string to CappedString
        public static implicit operator CappedString(string str)
        {
            return new CappedString(str);
        }
        // From CappedString to string
        public static implicit operator string(CappedString str)
        {
            return str.val;
        }
    
        // Then overload the rest of your operators for other common string operations
    }
