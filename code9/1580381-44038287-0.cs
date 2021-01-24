    class Borrower : IEnumerable<Borrower>
    {
        private string name;
        public string Name {get {return name;}}
        public Book Book {get; set;}
    
        public Borrower(string n)
        {
            this.Name = n;
        }
    }
