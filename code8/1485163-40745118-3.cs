    namespace AnonymousTypes
    {
        class Program
        {
            static string Serialize(object o)
            {
                var d = (dynamic)o;
                return d.ItemId.ToString() + d.ItemName + d.VenueId.ToString() + d.LocationName + d.VenueName;
            }
            static string GetData<T>(IEnumerable<T> result)
            {
                var retval = new StringBuilder();
                foreach (var r in result)
                    retval.Append(Serialize(r));
                return retval.ToString();
            }
            static string GetRestrictLookupInfo()
            {
                var restrictList = new[] { new { Id = 1, Name = "Music" }, new { Id = 2, Name = "TV" } };
                var tempProductGroupList = new[] { new { LocationName = "Paris", Id = 99, Name = "Royal Festival Hall" } };
                var result = from item in restrictList
                             from venue in tempProductGroupList
                             select new
                             {
                                 ItemId = item.Id,
                                 ItemName = item.Name,
                                 LocationName = venue.LocationName,
                                 VenueId = venue.Id,
                                 VenueName = venue.Name
                             };
                return GetData(result);
            }
            public static string GetData()
            {
                return GetRestrictLookupInfo();
            }
            static void Main(string[] args)
            {
                var result = GetData();
            }
        }
    }
