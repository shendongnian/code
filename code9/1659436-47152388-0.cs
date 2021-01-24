    [Key, Column(Order = 0)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid TenantId { get; set; }
