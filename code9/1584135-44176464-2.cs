    public abstract class AbstractPage<M, V> : AbstractPage<M>, ITest
        where M : AbstractPageEmenetsMap, new()
        where V : AbstractPageValidator<M>, new()
    {
        public AbstractPage(VendorInfo vendorInfo) : base(vendorInfo) { }
        public V Validate()
        {
            return new V();
        }
        public abstract void Login();
        public abstract void Logout();
    }
