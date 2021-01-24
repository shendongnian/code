    public class OverrideContractResolver : ContractResolverDecorator
    {
        readonly Dictionary<Type, IContractResolver> overrides;
        public OverrideContractResolver(IEnumerable<KeyValuePair<Type, IContractResolver>> overrides, IContractResolver baseResolver)
            : base(baseResolver)
        {
            if (overrides == null)
                throw new ArgumentNullException();
            this.overrides = overrides.ToDictionary(p => p.Key, p => p.Value);
        }
        public override JsonContract ResolveContract(Type type)
        {
            IContractResolver resolver;
            if (overrides.TryGetValue(type, out resolver))
                return resolver.ResolveContract(type);
            return base.ResolveContract(type);
        }
    }
    public class ContractResolverDecorator : IContractResolver
    {
        readonly IContractResolver baseResolver;
        public ContractResolverDecorator(IContractResolver baseResolver)
        {
            if (baseResolver == null)
                throw new ArgumentNullException();
            this.baseResolver = baseResolver;
        }
        #region IContractResolver Members
        public virtual JsonContract ResolveContract(Type type)
        {
            return baseResolver.ResolveContract(type);
        }
        #endregion
    }
