    public class FooRepository
    {
        private PersistenceRepository<FooPersistence> _innerRepository;
        public Foo GetFooById(int id)
        {
            return MapToDomain(_innerRepository.GetById(id));
        }
        public void Add(Foo foo)
        {
            _innerRepository.Add(MapToPersistence(foo));
        }
        public IEnumerable<Foo> GetByCity(string city)
        {
            return _innerRepository.Find(f => f.City == city).Select(MapToDomain);
        }
        private Foo MapToDomain(FooPersistence persistenceModel)
        {
            // Mapping stuff here
        }
        private FooPersistence MapToPersistence(Foo foo)
        {
            // Mapping stuff here
        }
    }
    public class PersistenceRepository<T> where T : PersistenceModel
    {
        public T GetById(int id)
        {
            //...
        }
        public void Add(T t)
        {
            //...
        }
        public IQueryable<T> Find(Func<T, bool> predicate)
        {
            //...
        }
    }
    public abstract class PersistenceModel
    {
    }
    public class FooPersistence : PersistenceModel
    {
        public string City { get; set; }
    }
