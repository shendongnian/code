    public string LastName { get; set; }  //OK
    public string Address { get; set; }   //OK 
    public string State { get; set; }     //OK
    public int? Zip { get; set; }         //OK
    public EmailAddressAttribute Email { get; set; } // NOT OK
    public PhoneAttribute PhoneNumber { get; set; }  // NOT OK
