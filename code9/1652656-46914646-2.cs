        public class Seller : BaseEntity
        {
            public Seller(string schoolName, string cardIdPath, string identityNumber, int customerId)
            {
                SchoolName = schoolName;
                CardIdPath = cardIdPath;
                IdentityNumber = identityNumber;
                CustomerId = customerId;
            }
    
            public string SchoolName { get; private set; }
            public string CardIdPath { get; private set; }
            public string IdentityNumber { get; private set; }
            public Customer Customer { get; private set; }
            public int CustomerId { get; private set; }
            public IEnumerable<Product> Products { get; private set; }
            public int? ProductId { get; private set; }
            public IEnumerable<Order> Orders { get; private set; }
    
        }
    }
