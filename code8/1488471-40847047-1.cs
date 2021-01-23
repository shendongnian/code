    public static Domain.ShopFloor.ShopFloorObject GetShopFloorOrder(string WorkOrd)
    {
        //As you can see here i'm checking on the output of this method, before trying to return it.
        Domain.ShopFloor.ShopFloorObject wo = Domain.ShopFloor.Shopfloor.GetOrder(WorkOrd);
        if (wo != null)
        {
            //If the value is not null (My method returns null if no result), return the object
            return wo;
        }
        //Same thing happens here. My method runs twice every time almost. 
        Domain.ShopFloor.ShopFloorObject yowo = Domain.DG9_DeliveryPerformance.DG9_DeliveryPerformance.GetObject(WorkOrd);
        else if(yowo != null)
        {
            return yowo;
        }
        else
        {
            return null;
        }
    }
