    public class MyEntity : Entity<string>
    {
        [NotMapped]
        public override string Id
        {
            get { return MyIntField + "-" + MyStringField ; }
            set { /* no need set */ }
        }
    
        [Key]
        [Column(Order = 1)]
        public virtual int MyIntField { get; set; }
    
        [Key]
        [Column(Order = 2)]
        public virtual string MyStringField { get; set; }
    
        public virtual string OtherField { get; set; }
    }
