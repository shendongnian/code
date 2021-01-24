    public abstract class Entity<TKey>
    {
        public TKey Id { get; }
        protected Entity() { }
        protected Entity(IIdentityFactory<TKey> identityFactory)
        {
            if (identityFactory == null)
                throw new ArgumentNullException(nameof(identityFactory));
            Id = identityFactory.CreateIdentity();
        }
    }
