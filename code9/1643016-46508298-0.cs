        #region Public Methods
        public async Task Initialise()
        {
            _Assemblies = new List<Assembly>();
            _Assemblies.Add(typeof(ReflectionUtils).GetTypeInfo().Assembly);
            _Assemblies.Add(Assembly.Load(new AssemblyName("Adapt.Model.Helpdesk")));
            _Assemblies.Add(typeof(SavePage).GetTypeInfo().Assembly);
            _Assemblies.Add(typeof(XivicClient.WCF.ServiceCalls.GeneralCalls).GetTypeInfo().Assembly);
            _Types = _Assemblies.SelectMany
               (
               a => a.GetTypes().Where
                   (
                       t => t.GetTypeInfo().GetCustomAttribute<DataContractAttribute>() != null ||
                       t.GetTypeInfo().GetCustomAttribute<CollectionDataContractAttribute>() != null
                   )
               ).ToList();
        }
        #endregion
