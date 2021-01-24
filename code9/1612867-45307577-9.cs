    public Ingredient()
    {
        // You don't need a collection of Recipes - 
        // you need a collection of Items.
        // Recipe = new HashSet<Recipes>();
    }
    .../...
    [ForeignKey("Item")] // change this
    public Item Item // include an Item object - the PK of the
        // Item is the FK of the Ingredient
    .../...
    // Remove Recipes
    // public virtual ICollection<Recipes> Recipe { get; set; }
    public virtual ICollection<Item> Items { get; set; }
