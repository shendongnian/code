    var dict = new Dictionary<string /*item_Id*/, int /*count*/>;
    // count redemptions for each id
    foreach(var item in cart)
    {
        if(dict.ContainsKey(item.Id))
             dict[item.Id]++;
        else
            dict.Add(item.Id, 1);
    }
    // check if any of them violate the allowed maximum
    foreach( var itemId in dict.Keys)
    {
        if(dict[itemId ] > GetMaxRedeemCount(itemId))
        {
            result.Invalidate(...);
            // you may want to break here...
            // break;
        }
    }
