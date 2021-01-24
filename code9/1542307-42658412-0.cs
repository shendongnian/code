    [ForeignKey(nameof(CompanyId))]
    public virtual Company Company { set; get; }
    
    [ForeignKey(nameof(CustomerId))]
    public virtual Company Customer { set; get; }
