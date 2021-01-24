    public class ClientManager
    {
        private readonly IUnitOfWorkFactory UowFactory;
        public ClientManager(IUnitOfWorkFactory<SubscriptionContext> uowFactory)
        {
            UowFactory = uowFactory;
        }
        public int Add(ClientModel model)
        {
            var entity = model.ToEntity();
            using (var uow = uowFactory.GetUoW())
            {  
                // dowork
            }
        }
    }
