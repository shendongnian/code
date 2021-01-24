    Request.ItemsElementName = new PaygateRef.ItemsChoiceType[]
    {
        PaygateRef.ItemsChoiceType.CardNumber,
        PaygateRef.ItemsChoiceType.CardExpiryDate
        
    };
    
    Request.Items = new string[] { "500000000000008", "012020" };
    
    Request.CVV = "001";// card ccv
