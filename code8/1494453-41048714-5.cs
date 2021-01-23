    class Superstring
    {
        int max_Length = 20;
        string theString;
    
        public Superstring() { }
        public Superstring(int maxLength) { max_Length = maxLength; }
        public Superstring(string initialValue) { Value = initialValue; }
        public Superstring(int maxLength, string initialValue) { max_Length = maxLength; Value = initialValue; }
    
        public string Value { get { return theString; } set { theString = string.IsNullOrEmpty(value) ? value : value.Substring(0, Math.Min(max_Length, value.Length)); } }
    }
