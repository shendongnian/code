    public static void AddItem(string itemName)
    {
        lock (ItemNamesLock)
        {
            //if (!itemName.Contains(itemName)) original
            if (!ItemNames.Items.Contains(itemName))
            {
                ItemNames.Items.Add(itemName);
            }
        }
    }
