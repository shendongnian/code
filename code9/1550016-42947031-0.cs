    public static class Tools
    {
        public static bool fDistinctProductType(this List<BasketOrderLine> lstToAnalyse)
        {
            BasketOrderLine ProductTypeA = lstToAnalyse.FirstOrDefault();
            if (ProductTypeA == null) // It's null when lstToAnalyse is empty
                return false;
            BasketOrderLine ProductTypeB = lstToAnalyse.Where(b => b.ProductType.Equals(ProductTypeA.ProductType)).FirstOrDefault();
            if (ProductTypeB == null) // It's null when it doesn't exists a distinct ProductType
                return false;
            return true;
        }
    }
