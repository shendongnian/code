    //FORM MODEL
    [ForeignKey("Type")]
    public int? TypeId { get; set; }
    public virtual FormType Type { get; set; }
    [ForeignKey("StatusTknype")]
    public int? StatusTypeId { get; set; }
    public virtual FormStatusType StatusTknype { get; set; }
    [ForeignKey("Supplier")]
    public int? SupplierId { get; set; }
    public virtual Relation Supplier { get; set; }
    [ForeignKey("Customer")]
    public int? CustomerId { get; set; }
    public virtual Relation Customer { get; set; }
    //RELATION MODEL
    [ForeignKey("Type")]
    public int? TypeId { get; set; }
    public virtual FormType Type { get; set; }
    [ForeignKey("StatusTknype")]
    public int? StatusTypeId { get; set; }
    public virtual FormStatusType StatusTknype { get; set; }
    [ForeignKey("Relation")]
    public int? SupplierId { get; set; }
    public virtual Relation Supplier { get; set; }
    [ForeignKey("Customer")]
    public int? CustomerId { get; set; }
    public virtual Relation Customer { get; set; }
