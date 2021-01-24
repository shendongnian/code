        public Borrower FindBorrower(string name)
        {
            var match = BorrowerList.Where(x => x.nameToCheck.Contains(name)).FirstOrDefault();
            return match;
        }
    }
    class Borrower
    {
        public string nameToCheck { get; set; }
        // the rest of class definitions...
    }
