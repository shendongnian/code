       public class Org : BaseEntity, IEntityBase
        {
            public string Name { get; set; }
            public ICollection<Portfolio> Portfolios  { get; set; }
        }
    
        public class Portfolio : BaseEntity, IEntityBase
        {
            public string Name { get; set; }
            public int OrganizationId { get; set; }
    
            [ForeignKey("OrganizationId")]
            public virtual Org Organization { get; set; }
            public bool IsPrivate { get; set; }
        }
