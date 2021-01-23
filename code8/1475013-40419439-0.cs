    public class ContactDto
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string Line4 { get; set; }
        public int CountryId { get; set; }
        public string PostalCode { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactTelephone { get; set; }
        public string ContactJobTitle { get; set; }
    }
    public class SupplierDto
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public int? SupplierTypeId { get; set; }
        public int? WebclicsManufacturerId { get; set; }
        public string SAPCode { get; set; }
        public ContactDto Contact { get; set; }
    }
