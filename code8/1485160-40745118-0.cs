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
    
            static object GetRestrictLookupInfo()
            {
                var restrictList = GetItem();
                var tempProductGroupList = GetVenue();
                return (from item in restrictList
                        from venue in tempProductGroupList
                        select new
                        {
                            ItemId = item.Id,
                            ItemName = item.Name,
                            LocationName = venue.LocationName,
                            VenueId = venue.Id,
                            VenueName = venue.Name
                        });
            }
            static void Main(string[] args)
            {
                var result = GetRestrictLookupInfo();
            }
        }
    }
