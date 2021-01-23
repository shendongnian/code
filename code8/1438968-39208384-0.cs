    public class Claim
    {
        public Person Member { get; set; }
        public Person Claimant { get; set; }
    
        public Claim()
        {
            this.Member = new Person() { PersonTypeID = 1 };
            this.Claimant = new Person() { PersonTypeID = 2 };
        }
    }
