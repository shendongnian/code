    class Person
    {
        private string nric;
        private string name;
    
        public Person(string nric, string name)
        {
            this.nric = nric;
            this.name = name;
        }
        public override string ToString()
        {
           return nric + " " + name;
        }
    }
