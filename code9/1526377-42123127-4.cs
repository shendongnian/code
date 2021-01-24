    var genericRequest = new GenericRequestData_Type();
    var contacts = new Contacts
    {
        Contact = new Contact
        {
            Name = "Patrick Hines",
            Phone = "206-555-0144",
            Address = new Address
            {
                Street1 = "123 Main St",
                City = "Mercer Island",
                State = "WA",
                Postal = "68042",
            },
        }
    };
    genericRequest.Any = new[] { contacts.AsXmlElement() };
