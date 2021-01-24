    public class CustomerInfoDto
    {
        public int CustomerId { get; set; }
        // ... some customer properties
        public int CustomerExtendedId { get; set; }
        // ... some additional properties
    }
    var info =  from c in db.Customers
                join e in db.CustomerExtended on c.Id equals e.CustomerId
                select new CustomerInfoDto
                {
                    CustomerId = c.Id,
                    Name = c.Name,
                    CustomerExtendedId = e.Id,
                    LastAccess = e.LastAccess
                };
