    public class CoordinateComparer : IEqualityComparer<Coordinates>
    {
        public bool Equals(Coordinates x, Coordinates y)
        {
            return (x.lat == y.lat && x.lon == y.lon);
        }
        public int GetHashCode(Coordinates obj)
        {
			unchecked
			{
				int hash = 17;
				if (obj != null)
				{
                    hash = hash * 23 + obj.lat.GetHashCode();
                    hash = hash * 23 + obj.lon.GetHashCode();
				}
                return hash;
			}
        }
    }
    public class Coordinates
	{
        public int lat { get; set; }
        public int lon { get; set; }
	}
    class MainClass
    {
        public static void Main(string[] args)
        {
            List<Coordinates> list = new List<Coordinates>();
			list.Add(new Coordinates { lat = 5, lon = 4 }); 
            list.Add(new Coordinates { lat = 4, lon = 5 });
			list.Add(new Coordinates { lat = 7, lon = 4 });
			list.Add(new Coordinates { lat = 6, lon = 3 });
			list.Add(new Coordinates { lat = 8, lon = 2 });
			double Delta = 1.1;
            List<Coordinates> results = new List<Coordinates>();
            foreach(Coordinates item in list)
            {
                // Find items that match the condition
                var matches = list.Where(x => Math.Abs(x.lat - item.lat) < Delta && Math.Abs(x.lon - item.lon) < Delta);
                // The 'item' will always match the condition with itself, which is undesirable, so remove it
                matches = matches.Except(new List<Coordinates> { item }, new CoordinateComparer());
                // Add the items that are not already in it to the results list
                foreach (Coordinates match in matches)
                {
                    if (!results.Contains(match, new CoordinateComparer()))
                        results.Add(match);
                }
            }
            foreach (Coordinates item in results)
                Console.WriteLine("Lat : {0}, Lon : {1}", item.lat, item.lon);
            
            Console.ReadLine();
		}   
    }
