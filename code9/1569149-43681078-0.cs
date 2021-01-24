    using Raven.Client.UniqueConstraints;
    
    public class MemberEligibility {
        [UniqueConstraint]
        public string EligibilityKey { get { return $"{MemberId}_{VendorId}_{PlanSponsorId}_{VendorContractKey}"; } }
        public long MemberId { get; set; }
        public int VendorId { get; set; }
        public int PlanSponsorId { get; set; }
        public string VendorContractKey { get; set; }
        // other fields
    }
