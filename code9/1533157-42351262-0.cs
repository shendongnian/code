    int i = 0, j = 0;
    while( i < parsedMerchantData.Count && j < HitCountItemIDS.Count)
    {
        var item = parsedMerchantData[i];
        var itemInB = HitCountItemIDS[j];
        if (itemInB.ItemID == item.ItemID)
        {
            item.TotalViews = (itemInB.HitCount > 0) ? itemInB.HitCount : 0;
            i++;
            j++;
        }
        else if(itemInB.ItemID < item.ItemID)
            i++;
        else  //itemInB.ItemID > item.ItemID
            j++;
    }
