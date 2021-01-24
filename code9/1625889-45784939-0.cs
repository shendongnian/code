    public class ApplicationUser : IdentityUser
    {
        // ...
        public ICollection<Referral> ReferrerOf { get; set; }
        public ICollection<Referral> CandidateOf { get; set; }
    }
