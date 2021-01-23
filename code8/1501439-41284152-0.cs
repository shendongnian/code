    public void AddItems(B_Item NewItem)
            {
                if (items.Count < MaxSlots)
                {
                    foreach (var i in items.ToArray())
                    {
                        if (i.Item_Name == NewItem.Item_Name )
                        {
                            if (i.Is_Stackable == true && i.StackSize < 500)
                            {
                                i.StackSize += 1;
                                return;
                            }
                        }
                    }
    
                }
                items.Add(NewItem);
    
            }
