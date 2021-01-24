    public int Id { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    [Required, StringLength(2048), DataType(DataType.MultilineText)]   
    public string body { get; set; }
    public string ImagePath { get; set; }
