    public class SomeConsumerOfProductRepository
    {
        private IProductRepository _repository;
    
        public SomeConsumerOfProcutRepository(IProductRepository repo)
        {
            this._repository = repo
        }
        public function UseProducts()
        {
            var products = this._repository.getProducts();
            //etc...
        }
    }
