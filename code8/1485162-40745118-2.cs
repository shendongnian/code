    namespace AnonymousTypes
    {
        sealed class Item
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    
        sealed class Venue
        {
            public string LocationName { get; set; }
            public int Id { get; set; }
            public string Name { get; set; }
        }
    
        sealed class ItemAndVenue
        {
            public int ItemId { get; set; }
            public string ItemName { get; set; }
            public string LocationName { get; set; }
            public int VenueId { get; set; }
            public string VenueName { get; set; }
        }
    
        class Program
        {
            static IEnumerable<Item> GetItem()
            {
                return new[] { new Item { Id = 1, Name = "Music" } };
            }
    
            static IEnumerable<Venue> GetVenue()
            {
                return new[] { new Venue { LocationName = "Paris", Id = 99, Name = "Royal Festival Hall" } };
            }
    
            static IEnumerable<ItemAndVenue> GetRestrictLookupInfo()
            {
                var restrictList = GetItem();
                var tempProductGroupList = GetVenue();
                var result = from item in restrictList
                        from venue in tempProductGroupList
                        select new ItemAndVenue
                        {
                            ItemId = item.Id,
                            ItemName = item.Name,
                            LocationName = venue.LocationName,
                            VenueId = venue.Id,
                            VenueName = venue.Name
                        };
                return result;
            }
    
            static string GetData()
            {
                var v = GetRestrictLookupInfo().First();
                return v.ItemId.ToString() + v.ItemName + v.VenueId.ToString() + v.LocationName + v.VenueName;
            }
    
            static void Main(string[] args)
            {
                var result = GetData();
            }
        }
    }
