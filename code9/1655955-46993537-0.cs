        class Program
        {
            static void Main(string[] args)
            {
                List<Gallery> galleries = new List<Gallery>();
                List<Rent> rents = new List<Rent>();
                var results = (from r in rents
                               join g in galleries on r.GallerId equals g.GallerId
                               select new { r = r, g = g })
                               .GroupBy(x => new { id = x.r.GallerId, address = x.r.Address })
                               .Select(x => new {
                                   count = x.Count(),
                                   id = x.Key.id,
                                   address = x.Key.address
                               })
                               .OrderByDescending(x => x.count)
                               .FirstOrDefault();
            }
        }
        public class Gallery
        {
            public int GallerId { get; set; }
        }
        public class Rent
        {
            public int GallerId { get; set; }
            public string Address { get; set; }
        }
