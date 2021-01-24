    public Item CreateItem(UserItem userItem)
    {
        var itemType = (ItemType)userItem.ItemType;
        switch(itemType)
        {
            case ItemType.Food: return new Food(userItem);
            case ItemType.Weapon: return new Weapon(userItem);
            // etc
            default:
                throw new NotSupportedException($"Item type {itemType} is not supported");
        }
    }
