    public class MyModel
    {
        public int MarketId { get; set; }
        public IEnumerable<TravelCentre> TravelCentres { get; set; }
    }
.
    var result = db.Markets
                .Where(c => c.IsActive == true)
                .Select(p => new MyModel()
                {
                    Market = p.MarketId,
                    TravelCentres = p.TravelCentres.Where(x => x.IsActive == true)
                });
    return (IQueryable<MyModel>)result;
