    public class Challenge
    {
        public int Id { get; set; }
        public string ChallengeId {get; set;}
        public string Name { get; set; }
        public string Description { get; set; }
        
        //Add these properties
        public int UserAccountId{get;set;}
        public UserAccount UserAccount{get;set;}
    
        public virtual List<Competitor> Competitors { get; set; }
    }
