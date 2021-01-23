    class Superstring
    {
        int Max_Length = 20;
        public Superstring()
        {
    
        }
        public Superstring(int Max_Length)
        {
            this.Max_Length = Max_Length;
        }
    
        string theString;
        public string Value { get { return theString; } set { theString = value.Substring(0, Math.Min(Max_Length, value.Length)); } }
    }
