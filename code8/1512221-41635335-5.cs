    public Inventory()
    {
        inventory = new List<Item>
        {
           Item.CreatePotionHP(), // creation method
           new Item("AT Potion","Restores Attack by 1.", 8, 10), // constructor
           Item.CreatePotionHP(),
           new Item("Revive","Revives upon death with 5 HP.", 8, 10)
        }
     }   
