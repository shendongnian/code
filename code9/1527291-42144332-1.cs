    public class InsightsModelFactory : FactoryBase {
        private readonly IDictionary<LocalListingEngagement, Func<IDbSessionManager, IModelBuilder>> strategies;
        private readonly IDbSessionManager dbSessionManager;
        public InsightsModelFactory(IDbSessionManager dbSessionManager) {
            this.dbSessionManager = dbSessionManager;
            strategies = new Dictionary<LocalListingEngagement, Func<IDbSessionManager, IModelBuilder>>();
            //...populate available builders or create an abstraction that can be injected.
        }
        public override IModelBuilder Create(LocalListingEngagement type) {
            Func<IDbSessionManager, IModelBuilder> stratergy;
            if (strategies.TryGetValue(type, out stratergy)) {
                return stratergy(dbSessionManager);                    
            } else {
                throw new NotImplementedException();
            }
        }
    }
