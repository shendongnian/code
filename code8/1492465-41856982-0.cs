    public class BusinessConfiguration : ResourceTypeBuilder<Business>
    {
        public BusinessConfiguration()
        {
            this.ResourceIdentity(x => x.idBus).SetApiType("business");
            
        }
    }
