    public int? UserId { get; set; }
    [ForeignKey("UserId")]
    public User User { get; set; }
    public int? AcceptedById { get; set; }       
    [ForeignKey("AcceptedById")] 
    public User AcceptedBy { get; set; }
