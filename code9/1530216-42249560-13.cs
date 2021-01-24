    public static class EntityManagerProvider
    {
        public static EntityManager<Q> GetManager<Q>()
        {
            if (typeof(INamedIdentity).IsAssignableFrom(typeof(Q)))
                return typeof(NamedEntityManager<>).MakeGenericType(typeof(Q)).GetConstructor(new Type[] { }).Invoke(new Type[] { }) as MyClass<Q>;
            if (typeof(IKeyedIdentity).IsAssignableFrom(typeof(Q)))
                return typeof(KeyedEntityManager<>).MakeGenericType(typeof(Q)).GetConstructor(new Type[] { }).Invoke(new Type[] { }) as MyClass<Q>;
            return null;
        }
        public abstract class EntityManager<T>
        {
            public void Create(T entity) { ... }
            public void Update(T entity) { ... }
            public abstract T GetById(long id);
            public abstract T GetByName(string name);
        }
        private class KeyedEntityManager<Q> : EntityManager<Q> where Q : IKeyedIdentity
        {
            public override Q GetById(long id) { return default(Q); }
            public override Q GetByName(string name) { throw new NotSupportedException(); }
        }
        private class NamedEntityManager<Q> : EntityManager<Q> where Q : INamedIdentity
        {
            public override Q GetById(long id) { throw new NotSupportedException(); }
            public override Q GetByName(string name) { return default(Q); }
        }
    }
