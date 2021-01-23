    class Superstring
    {
        int max_Length = 20;
        string theString;
    
        public Superstring()
        {
    
        }
        public Superstring(int max_Length)
        {
            this.max_Length = max_Length;
        }
        public Superstring(string initialValue)
        {
            theString = initialValue;
        }
    
        public string Value { get { return theString; } set { theString = value.Substring(0, Math.Min(max_Length, value.Length)); } }
    }
