    public Ingredient()
    {
        // You don't need a collection of Recipes - 
        // you need a collection of Items.
        // Recipe = new HashSet<Recipes>();
    }
    .../...
    [ForeignKey("Item")] // change this
    .../...
    // Remove Recipes
    // public virtual ICollection<Recipes> Recipe { get; set; }
    public virtual ICollection<Item> Items { get; set; }
