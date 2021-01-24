    public Recipes()
    {
        disciplines = new List<string>();
        Item = new Item(); // Change this.
    }
    .../...
    [ForeignKey("Item")] // Change this
    public Item Item { get; set;}
    .../...
    // I'm assuming this is a list?
    public virtual ICollection<Item> Items { get; set; } 
 
    public Items()
    {
        Recipes = new HashSet<Recipe>(); // Change this
    }
    .../...
    // You don't need this list
    public virtual ICollection<Recipe> Recipes { get; set; } 
