    public class CompositeContractResolver : IContractResolver, IEnumerable<IContractResolver>
    {
        private readonly IList<IContractResolver> _contractResolvers = new List<IContractResolver>();
        public JsonContract ResolveContract(Type type)
        {
            return
                _contractResolvers
                    .Select(x => x.ResolveContract(type))
                    .FirstOrDefault(Conditional.IsNotNull);
        }
        public void Add([NotNull] IContractResolver contractResolver)
        {
            if (contractResolver == null) throw new ArgumentNullException(nameof(contractResolver));
            _contractResolvers.Add(contractResolver);
        }
        public IEnumerator<IContractResolver> GetEnumerator()
        {
            return _contractResolvers.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
