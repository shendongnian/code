    public static ShoppingList Create(ShoppingObject s)
    {
        ShoppingList slist = new ShoppingList();
        if (s == null)
        {
            return slist;
        }
        slist.Id = s.Id;
        slist.Name = s.Name;
        // etc...
                
        return slist;
    }
