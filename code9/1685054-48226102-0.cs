    //To Universe Class
    [InverseProperty("Server")]
    public List<Player> Players { get; set; } = new List<Player>();
    
    //To Player Class
    public int ServerId { get;set; }
    [ForeignKey("ServerId")]
    public Universe Server { get; set; }
