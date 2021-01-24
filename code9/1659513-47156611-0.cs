      public class Person:IdentityUser
            {
                public string IdUser { get; set; }
                public string Name { get; set; }
                public string Surname { get; set; }
                public string role { get; set; }
            }
        
    
    
    public class Customer:Person
        {
            public int Age { get; set; }
            public int Weight { get; set; }
            public int Height { get; set; }
    
            public string getCustomerName()
            {
                return base.Name;
            }
            public void setCustomerName(string name)
            {
                base.Name = name;
            }
        }
    
    
    public class Trainer:Person
        {
            public List<Customer> Customers { get; set; }
        }
