    public class ExternalLink
    {
        ...
        [ForeignKey("AffiliateProgram")]
        public int AffiliateProgramId { get; set; }
        public virtual AffiliateProgram AffiliateProgram { get; set; }
    }
