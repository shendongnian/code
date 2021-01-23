    public class ShopFloorDBRepository
    {
        public static Domain.ShopFloor.ShopFloorObject GetShopFloorOrder(string workOrd)
        {
            return Domain.ShopFloor.Shopfloor.GetOrder(workOrd) ??
                   Domain.DG9_DeliveryPerformance.DG9_DeliveryPerformance.GetObject(workOrd);
        }
    }
