    [Table("Address")]
    public class AddressDao
    {
        public Guid Id { get; set; }
        
        [ForeignKey("Person_Id")] 
        public PersonDao Person { get; set; }
        // other properties
    }
