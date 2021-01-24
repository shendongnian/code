    CardSlot ReturnLowestCardSlot(double lowestPrice, List<CardSlot> list)
    {
        CardSlot cardslot = null;
        foreach (var item in list)
        {
            if (item.Price == lowestPrice)
            {
                cardslot = item;
                break;
            }
        }
        return cardslot;
    }
