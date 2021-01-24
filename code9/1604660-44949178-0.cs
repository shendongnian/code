    public abstract class Entity : IEntity
    {
        public long Id { get; }
        public static ConcurrentDictionary<Type, dynamic> CurrentRepository = new ConcurrentDictionary<Type, dynamic>();
        public Entity(Entity ent)
        {
            GetRepository(ent);
        }
        private static dynamic GetRepository(Entity ent)
        {
            Type entityType = ent.GetType();
            return CurrentRepository.GetOrAdd(entityType, type =>
            {
                var instance = Activator.CreateInstance(typeof(Repository<>).MakeGenericType(entityType));
                return instance;
            });
        }
        public Entity()
        {
        }
        public void Save()
        {
            var repo = GetRepository(this);
            repo.Save((dynamic)this);
        }
        public void Delete()
        {
            var repo = GetRepository(this);
            repo.Delete((dynamic)this);
        }
    }
