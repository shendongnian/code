    class Borrower : IEnumerable<Borrower>
    {
        public string Name {get; private set;}
        public Book Book {get; set;}
    
        public Borrower(string n)
        {
            this.Name = n;
        }
    }
