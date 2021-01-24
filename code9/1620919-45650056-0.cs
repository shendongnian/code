    public class Sku : Identity<Product>
    {
        public VendorId VendorId { get; }
        public string Value { get; }
    }
    public class VendorId : Identity<Vendor>
    {
        public string Value { get; }
    }
    BsonClassMap.RegisterClassMap<Product>(cm =>
    {
       cm.AutoMap();
       cm.MapIdMember(c => c.Sku);
       cm.MapProperty(c => c.Identity);
    });
     
