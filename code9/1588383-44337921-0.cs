    public class Recursive
    {
        BlogContext db = new BlogContext();
        public int Counter { get; set; } = 0;
        public Recursive()
        {
            db.Database.Log += (str) => //this will log all the calls to the database.
            {
                System.Diagnostics.Debug.WriteLine(str, "Sql Query: ");
            };
        }
        public List<Location> StartRecursive()
        {
            return GetChild(50).ToList();
        }
        public IEnumerable<Location> GetChild(int id)
        {
            var locations = db.Locations
            .Where(x => x.ParentLocationID == id || x.LocationID == id).ToList();
            if (locations.Count == 1) return locations;
            var locationSubset = locations.Where(tt=>tt.LocationID!=id)
            .SelectMany(tt => GetChild(tt.LocationID)).ToList();
            Counter++;
            return locations.Union(locationSubset);
        } 
