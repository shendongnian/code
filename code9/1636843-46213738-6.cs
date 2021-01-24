    class Location {
        public string location { get; set; }
        public DateTime date { get; set; }
    }
    var distincts = locationsList 
             .GroupBy(location => location.location)
             .Select(grp => new Location {
                 location = grp.Key, 
                 date = grp.Max(loc => loc.date)
             });
