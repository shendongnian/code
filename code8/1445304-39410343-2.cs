    public class MeasurementListRepository
    {
        readonly IDbConnection _db;
        public MeasurementListRepository(IDbConnection db)
        {
            _db = db;
        }
        public IList<Location> GetLocations()
        {
            return _db.Query<Location>(@"select * from Location").ToList();
        }
    }
