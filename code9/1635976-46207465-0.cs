    public class Address : ValueObject
        {
            public Address(string street, int number)
            {
                Street = street;
                Number = number;
            }
    
            public string Street { get; private set; }
            public int Number { get; private set; }
    
    
            #region Value object workaround
            public Address WithStreet(string value) => new Address(value, Number);
    
            public Address WithNumber(int value) => new Address(Street, value);
            #endregion
        }
        public class Company : AggregateRoot
        {
    
            #region public public Address Address { get; set; }
            [NotMapped]
            public Address Address { get; set; }
    
            //In the DbContext this property needs to be mapped with a column in a database
            private string Address_Street
            {
                get { return Address.Street; }
                set { Address = Address.WithStreet(value); }
            }
    
            //In the DbContext this property needs to be mapped with a column in a database
            private int Address_Number
            {
                get { return Address.Number; }
                set { Address = Address.WithNumber(value); }
            }
            #endregion
    
            
            // Other properties...
    
            // Value objects are immutables so I'm only able to replace it with a new object.
            public void UpdateAddress(string street, int number)
            {
                Address = new Address(street, number);
            }
            // Other methods...
        }
