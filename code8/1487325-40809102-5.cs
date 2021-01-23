    public class OrderProvider : IOrderProvider
    {
        private readonly ClaimsIdentity identity;
        public OrderProvider(IPrincipalProvider provider) {
            identity = (ClaimsIdentity)provider.User.Identity;
        }
    }
