    public class CustomerBase
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    
        [NotMapped]
        public string Address1 { get; set; }
    
        [NotMapped]
        public string Address2 { get; set; }
    
        [NotMapped]
        public string Phone { get; set; }
    
        [NotMapped]
        public string Fax { get; set; }
    
    }
    
    public class Customer : CustomerBase
    {
        public virtual List<Addresses> Addresses { get; set; }
    }
    
    public class Addresses
    {
        [Key]
        public int AddressID { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public bool IsDefault { get; set; }
        public int SerialNo { get; set; }
        public virtual List<Contacts> Contacts { get; set; }
    
        public int CustomerID { get; set; }
        //[ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }
    }
    
    public class Contacts
    {
        [Key]
        public int ContactID { get; set; }
    
        public string Phone { get; set; }
        public string Fax { get; set; }
        public bool IsDefault { get; set; }
        public int SerialNo { get; set; }
        public int AddressID { get; set; }
    
        //[ForeignKey("AddressID")]
        public virtual Addresses Addresses { get; set; } 
    
    }
