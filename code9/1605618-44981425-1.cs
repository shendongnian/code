        public class Customer {
        	public int Id { get; set; }
        	public string Name { get; set; }
        	public int AddressId { get; set; }	
        	public int ContactId { get; set; }
        	public Address Address { get; set; }
        	public Contact Contact { get; set; }
        }
        
        public class Address {
          public int Id { get; set; }
          public string Address1 {get;set;}
          public string Address2 {get;set;}
          public string City {get;set;}
          public string State {get;set;}
          public int ZipCode {get;set;}
          public IEnumerable<Customer> Customer {get;set;}
        }
        
        public class Contact {
        	public int Id { get; set; }
        	public string Name { get; set; }
        	public IEnumerable<Customer> Customer {get;set;}
        }
        
        using (var conn = GetOpenConnection())
        {
        	var query = _contextDapper
        		.Query<Customer, Address, Contact, Customer>($@"
        			SELECT c.Id, c.Name, 
        				c.AddressId, a.Id, a.Address1, a.Address2, a.City, a.State, a.ZipCode,
        				c.ContactId, ct.Id, ct.Name
        			FROM Customer c
        			INNER JOIN Address a ON a.Id = c.AddressId
        			INNER JOIN Contact ct ON ct.Id = c.ContactId", 
        			(c, a, ct) =>
        			{
        				c.LogType = a;
        				c.Contact = ct;
        				return c; 
        			}, splitOn: "AddressId, ContactId")
        		.AsQueryable();
        			
        	return query.ToList();			
        }
