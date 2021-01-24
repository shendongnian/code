        var q = from c in db.Customer      // .Include(c => c.Orders) ?
                from o in c.Orders         // .DefaultIfEmpty() ?
                select new
                {
                    c.CustomerName,
                    o.Description,
                    o.Country.CountryName, // those two are the (navigation) properties on the Order class
                    o.City.CityName
                };
        public class Order
        {
            public Customer Customer { get; set; }
            public City City { get; set; }
            // public Country Country { get; set; }
        }
        internal class OrderConfiguration : EntityTypeConfiguration<Order>
        {
            public OrderConfiguration()
            {
                // EF fluent API goes here
            }
        }
