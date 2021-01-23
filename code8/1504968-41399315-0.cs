    public class Service<T> : IService<T>
        where T : class 
    {
        private IRepository<T> _repository;
        public Service(IRepository<T> repo) {
            this._repository = repo;
        }
        public IEnumerable<T> GetAll() {
            return _repository.GetAll();
        }
