    //Change this:
    public HashSet<ProductStory> ProductStories { get; set; }
    //For this (virtual is needed here, also use ICollection rather than any specific implementation)
    public virtual ICollection<ProductStory> ProductStories { get; set; }
    //Change this:
    public virtual Product.Product Product { get; set; }
    //For this (virtual makes no sense here)
    public Product.Product Product { get; set; }
