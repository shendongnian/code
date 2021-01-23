    [Key, Column(Order = 0)]
    public string LoginProvider { get; set; }
    
    [Key, Column(Order = 1)]
    public string ProviderKey { get; set; }
    
    [Key, Column(Order = 2)]
    public int ApplicationUserId { get; set; }
