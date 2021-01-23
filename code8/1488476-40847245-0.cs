    public class ShopFloorDBRepository
    {
      public static Domain.ShopFloor.ShopFloorObject GetShopFloorOrder(string WorkOrd)
      {
        var result = Domain.ShopFloor.GetOrder(WorkOrd);
        if (result != null) return result;
        ...
