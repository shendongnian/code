    public class Claim
    {
        public Person Member { get; set; }
        public Person Claimant { get; set; }
    
        public Claim(int MemberTypeID, int ClaimantTypeID)
        {
            this.Member = new Person() { PersonTypeID = MemberTypeID };
            this.Claimant = new Person() { PersonTypeID = ClaimantTypeID };
        }
    }
