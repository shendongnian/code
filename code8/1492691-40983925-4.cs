    public class MyDataService<TObject> where TObject : class {
        private readonly IGenericRepository<TObject> repository;
        public MyDataService(IGenericRepository<TObject> repository) {
            this.repository = repository;
        }
        public TObject Update(TObject obj, int id) {
            return repository.Update(obj, id);
        }
    }
