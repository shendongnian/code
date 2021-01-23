    ...
    CU.Contacts = db.Contacts.ToList();
    CU.Companies = db.Companies.ToList();
    
    foreach(var contact in CU.Contacts)
    {
        contact.Companies = CU.Companies
                          .Where(com => com.CompanyId == contact.CompanyId)
                          .ToList();
    }
    ---
