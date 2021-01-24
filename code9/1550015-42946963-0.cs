    public class BasketModel
    {
        public BasketModel()
        {
            BasketOrderLines = new List<BasketOrderLine>();
        }
        public bool HasMulitpleDistinctProducts
        {
            get
            {
                if (!BasketOrderLines.Any())
                {
                    return true; // or false?
                }
                return BasketOrderLines.Select(b => b.ProductType).Distinct().Count() > 1;
            }
        }
    }
