    public class LocationLookupService
    {
        private readonly DataContext _context;
        public LocationLookupService(DataContext context)
        {
            _context = context;
        }
        public List<MyLocations> GetLocations()
        {            
            var locations = _context.MyLocations.OrderBy(x => x.Name).ToList();
            return locations;
        }
    }
