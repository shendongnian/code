    public class Sku : Identity<Product>
    {
        public readonly VendorId VendorId;
        public readonly string SkuValue;
        public Sku(VendorId vendorId, string skuValue)
        {
            VendorId = vendorId;
            SkuValue = skuValue;
        }
        protected override IEnumerable<object> GetIdentityComponents()
        {
            return new object[] {VendorId, SkuValue};
        }
    }
