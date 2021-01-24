    [DisplayName("Referral")]
    [Column("ReferralId")]
    [ForeignKey("Referral")]
    public int ParentID { get; set; }
    ...
    public virtual Referral Referral { get; set; }
