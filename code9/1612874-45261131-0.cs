    public class sortPurchaseCostAscendingHelper : IComparer<IZoo>
    {
        public int Compare(IZoo z1, IZoo z2)
        {
            if (z1.PurchaseCost > z2.PurchaseCost)
                return 1;
    
            if (z1.PurchaseCost < z2.PurchaseCost)
                return -1;
    
            else
                return 0;
        }
    }
