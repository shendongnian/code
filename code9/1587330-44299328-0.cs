     public int Id { get; set; }
     public string Name { get; set; }
     public string Address1 { get; set; }
     public string Address2 { get; set; }
     public string City { get; set; }
     public string State { get; set; }
     public string Country { get; set; }
     public string ZipCode { get; set; }
     public int CustomerId { get; set; }
     public int VendorId { get; set; }
     // Navigation properties
     public Customer Customer { get; set; }
     public Vendor Vendor { get; set; }
