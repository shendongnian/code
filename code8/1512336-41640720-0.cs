    public class MerchantConfigurationRepository {
        private readonly IRepository<MerchantConfigurationEntity> repository;
        public MerchantConfigurationRepository(IRepository<MerchantConfigurationEntity> repositiry) {
            this.repository = repository;
        }
    
        //...other code
    
        public Task<int> UpdateMerchant(Merchant model) { ... }
    }
