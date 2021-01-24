    public class VendorId : Identity<Vendor>
    {
        public readonly string VendorShortname;
        public VendorId(string vendorShortname)
        {
            VendorShortname = vendorShortname;
        }
        protected override IEnumerable<object> GetIdentityComponents()
        {
            return new object[] {VendorShortname};
        }
    }
