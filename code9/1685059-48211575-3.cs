    /// <summary>
    /// Facade implementation in terms of a particular POCO and database technology.
    /// </summary>
    internal sealed class BusinessObjectXImpl : BusinessObjectX
    {
        private readonly BusinessObjectXPoco poco;
        internal BusinessObjectXImpl(BusinessObjectXPoco poco)
        {
            this.poco = poco;
        }
        public override string SomeProperty => poco.SomeProperty;
    }
    /// <summary>
    /// Allows the lookup of <see cref="BusinessObjectX"/> instances 
    /// from POCOs - has the lifecycle of a transaction.
    /// </summary>
    internal sealed class BusinessObjectXFacadeLookup
    {
        private readonly Func<BusinessObjectXPoco, BusinessObjectX> createFunc;
        private readonly Dictionary<Guid, BusinessObjectXImpl> lookup 
            = new Dictionary<Guid, BusinessObjectXImpl>();
        public BusinessObjectXFacadeLookup(Func<BusinessObjectXPoco, BusinessObjectX> createFunc)
        {
            this.createFunc = createFunc;
        }
        public BusinessObjectX GetOrCreate(BusinessObjectXPoco poco)
        {
            BusinessObjectXImpl ret;
            if (!lookup.TryGetValue(poco.Id, out ret))
            {
                ret = new BusinessObjectXImpl(poco);
                lookup.Add(poco.Id, ret);
            }
            return ret;
        }
    }
    /// <summary>
    /// Technology specific repository implementation.
    /// </summary>
    internal sealed class BusinessObjectXRepoConcrete : BusinessObjectXRepoAbstraction
    {
        private readonly BusinessObjectXDatabaseRepo databaseRepo;
        private readonly BusinessObjectXFacadeLookup lookup;
        public BusinessObjectXRepoConcrete(BusinessObjectXDatabaseRepo databaseRepo, 
            BusinessObjectXFacadeLookup lookup)
        {
            this.databaseRepo = databaseRepo;
            this.lookup = lookup;
        }
        public override BusinessObjectX Create(string mandatoryPropertyValue)
        {
            var poco = databaseRepo.CreateNew();
            poco.SomeProperty = mandatoryPropertyValue;
            return lookup.GetOrCreate(poco);
        }
    }
