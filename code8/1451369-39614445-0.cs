    [Index("IdAndTitle", 1, IsUnique = true)]
    public string Title { get; set; }
    [Index("IdAndTitle", 2]
    public int BlogId { get; set; }
    
