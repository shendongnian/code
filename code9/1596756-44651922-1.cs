    class CombinedFooDataService : IFooDataService
    {
        private static readonly IFooDataService[] _services;
        public CombinedFooDataService( params IFooDataService[] services )
        {
            _services = services;
        }
    
        public async Task<ICollection<Foo>> GetAllAsync()
        {
            var tasks = _services.Select( e => e.GetAllAsync() );
            var results = await Task.WhenAll( tasks );
            return results.SelectMany( e => e ).ToList();
        }
    }
