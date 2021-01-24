    class Borrower
    {
        public string Name { get; }
        public Book Book { get; set; }
    
        public Borrower(string n)
        {
            //Since C# 6.0, read-only properties can be set in the constructor
            this.Name = n; 
        }
    }
