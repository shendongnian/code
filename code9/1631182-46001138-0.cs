    class MefContainer
    {
        public CompositionContainer Container { get; }
        public MefContainer()
        {
            var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly()); // You can use an AggregateCatalog if you have more than one assembly.
            Container = new CompositionContainer(catalog);
            Container.ComposeParts(this);
        }
    }
