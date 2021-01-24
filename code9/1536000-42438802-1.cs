    [Table("GICSSectors")]
    public class GICSSector: Sector
    {
        public virtual ICollection<GICSIndustryGroup> IndustryGroups {get; set;}
    }
