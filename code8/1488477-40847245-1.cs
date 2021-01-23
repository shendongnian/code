    public static ShopFloorObject GetShopFloorOrder(string WorkOrd)
    {
        ShopFloorObject result;
        if ( (result = Domain.ShopFloor.GetOrder(WorkOrd)) != null )
            return result;
        if ( (result = Domain.DG9_DeliveryPerformance.DG9_DeliveryPerformance.GetObject(WorkOrd)) != null)
            return result;
        return null;
