    public int Count { get; set; }
    public int Fee { get; set; }
    public int Total { get; set; }
    
    [NotMapped]
    public int CalculatedTotal
    {
    	get { return Count*Fee; }
    }
