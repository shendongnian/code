    Dictionary<string, ABC_TYPE> dict = HitCountItemID.GropupBy(x => x.ItemID, y => y).ToDictionary(x => x.Key, y => y.FirstOrDefault())
    foreach (var item in parsedMerchantData)
    {
        var itemInB = dict[item.ItemID];
        if (itemInB != null)
        {
            if (itemInB.HitCount != -1)
            {
                item.TotalViews = itemInB.HitCount;
            }
            else
            {
                item.TotalViews = 0;
            }
        }
    }
