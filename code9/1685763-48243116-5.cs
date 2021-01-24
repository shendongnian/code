    var v2 = new ThirdPartyOrderV2
    {
        Amount = 5.00M,
        DontNeedThis = "Who cares",
        LineItems = new ThirdPartyOrderItemV2[]
        {
            new ThirdPartyOrderItemV2 {ItemID = 5, Quantity = 200},
            new ThirdPartyOrderItemV2 {ItemID = 4, Quantity = 50}
        }
    };
    var v1 = Mapper.Map<ThirdPartyOrderV1>(v2);
    var myOrder = v1.ToMyOrder();
