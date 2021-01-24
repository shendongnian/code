    CardAction pbv = new CardAction()
    {
        Value = "postbackval-category-C1",
        Type = "imBack",
        Title = "image Page"
    };
    
    ReceiptCard plCard = new ReceiptCard()
    {
        Title = "Receipt Card",
        Items = receiptList,
        Total = "112.77",
        Tax = "27.52",
        Tap = pbv
    };
    
    
    if (activity.Text.StartsWith("postbackval"))
    {
        string category = activity.Text.Split('-')[2].ToString();
    
        //retriveve more details based on postback value
    }
    else
    {
        //do other operations  
    }
