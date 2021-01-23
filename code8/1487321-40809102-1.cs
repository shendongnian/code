    public class OrderProvider : IOrderProvider {
        private readonly ClaimsIdentity identity;
        public OrderProvider(IPrincipleProvider provider) {
            identity = (ClaimsIdentity)provider.User.Identity;
        }
        //...other code
    }
