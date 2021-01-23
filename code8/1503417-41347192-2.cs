    [Table("Person")]
    public class PersonDao
    {
        public Guid Id { get; set; }
        public ICollection<Address> Addresses { get; set; }
        // other properties
    }
    [Table("Address")]
    public class AddressDao
    {
        public Guid Id { get; set; }
        public Guid MyPersonDaoColumnName { get; set; }
        public PersonDao Person { get; set; }
        // other properties
    }
