    [Required]
    public long ClassId1 { get; set; }
    public long? ClassId2 { get; set; }
    [ForeignKey("ClassId1")]
    public virtual Class Class1 { get; set; }
    [ForeignKey("ClassId2")]
    public virtual Class Class2 { get; set; }
