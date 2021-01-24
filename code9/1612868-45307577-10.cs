    public Recipes()
    {
        disciplines = new List<string>();
        ingredients = new HashSet<Ingredient>();
    }
    .../...
    // [ForeignKey("Items")] remove this
    [ForeignKey("Ingredient")] 
    public Ingredient Ingredient // include as Ingredient object 
        // the PK of the Ingredient is the FK for the Recipe
    .../...
    public virtual ICollection<Ingredient> Ingredients { get; set; }
    // The Recipe does not have an Item, the Ingredient has 
    // has a collection of <Item> Items
    // public virtual Items Items { get; set; }
