    public int ProjectID { get; set; }
    [Index("ProjectNumber_Index", IsUnique = true)]
    [MaxLength(200)]
    public string ProjectNumber { get; set; }
    public string ProjectDescription { get; set; }
