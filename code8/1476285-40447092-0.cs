    public static int findKeyofCorrespondingItem(Items[] items, string searchValue)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].itemId == searchValue)
                {
                    return i;
                }
            }
    
            return -1;
        }
