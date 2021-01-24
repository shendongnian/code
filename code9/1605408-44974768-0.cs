    public class ApprovalRuleset
    {
        public Guid Id { get; set; }
        public List<ApprovalRule> ApprovalRules { get; protected internal set; }
    }
    
    public class ApprovalRule
    {
        public Guid Id { get; set; }
        public string Value { get; protected internal set; }
    
        public int ApprovalRulesetId { get; set; }
        public virtual ApprovalRuleset ApprovalRuleset { get; set; }
    }
    
    public class ApprovalRulesetEntityConfiguration : EntityTypeConfiguration<ApprovalRuleset>
    {
        public ApprovalRulesetEntityConfiguration()
        {
            HasKey(t => t.Id);
        }
    }
    
    public class ApprovalRuleEntityConfiguration : EntityTypeConfiguration<ApprovalRule>
    {
        public ApprovalRuleEntityConfiguration()
        {
            HasKey(t => t.Id);
                
            /*Property(t => t.Value)
                .HasMaxLength(100);*/
    
            HasRequired(t => t.ApprovalRuleset)
                .WithMany(t => t.ApprovalRules)
                .HasForeignKey(d => d.ApprovalRulesetId);
        }
    }
