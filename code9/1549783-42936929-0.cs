    [RequiredNotDefault]
    public int UserAccountId { get; set;}
    
    [ForeignKey("UserAccountId")]
    public virtual UserAccount Customer { get; set; }
