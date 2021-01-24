    public class Company
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Promo { get; set; } 
        public virtual List<Contact> Contacts { get; set; }       
    }
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }
        [ForeignKey("Company")]
        public int CompanyID { get; set; }
        public virtual Company Company { get; set; }
        public string ContactName { get; set; }
        public string ContactNumber { get; set; }
    }
