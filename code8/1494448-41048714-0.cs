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
        public string TheString { get { return theString; } set { theString = value.Substring(0, Max_Length); } }
    }
