    group p by new
    {
        p.ContactID,
        p.Field2,
        p.Field3
    }into g
    select new PaymentItemModel()
    {
        ContactID = g.Key.ContactID,
        anotherField = g.Key.Field2,
        nextField = g.Key.Field3       
    };
