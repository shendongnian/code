    var customer = new Customer();
    customer.Profile = new CustomerProfile();
    customer.Company = new Company();
    customer.Contacts = new List<Contact>();
    
    var withCompany = customer as IHasAssociation<Company>;
    var withCustomerProfile = customer as IHasAssociation<CustomerProfile>;
    var withContacts = customer as IHasManyAssociation<IList<Contact>, Contact>;
    
    if (withCompany != null)
    {
    	Company company = withCompany.Association;
    	Console.WriteLine("This object has an associated company!");
    }
    
    if (withCustomerProfile != null)
    {
    	CustomerProfile profile = withCustomerProfile.Association;
    	Console.WriteLine("This object has a profile!");
    }
    
    if (withContacts != null)
    {
    	IList<Contact> contacts = withContacts.Association;
    	Console.WriteLine("This object has contacts!");
    }
