    using System.ComponentModel.DataAnnotations.Schema;
    
    public class User
    {
        public int Id { get; set; }
    
        // The complex property we want to use
        public Address Address { get; set; }
    
        public string UserName{ get; set; }
    }
    // Lets Entity Framework know this class is a complex type
    [ComplexType]
    public class Address
    {
        // Maps the property to the correct column name
        [Column("Address")]
        public string StreeAddress { get; set; }
    
        [Column("City")]
        public string City { get; set; }
    
        [Column("State")]
        public string State { get; set; }
    
        [Column("Zip")]
        public string ZipCode { get; set; }
    }
