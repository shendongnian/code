    [Key]
    public int PreferenceId { get; set; }
    [ForeignKey("Profile"), Column(Order = 0)]
    public int UserId { get; set; }
    public virtual Profile Profile { get; set; }
    ...
