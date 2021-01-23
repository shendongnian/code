    public ActionResult Index(String Page)
    {
        ContactsUni2 CU = new ContactsUni2();
        CU.Contattis = db2.Contatti.ToList();
        CU.Contacts = db.Contacts.ToList();
        CU.Companies = db.Companies.ToList();
        foreach(var contact in CU.Contacts)
        {
            contact.Companies = CU.Companies
                              .Where(com => com.CompanyId == contact.CompanyId)
                              .ToList();
        }
        List<ContactsUni2> contactlist = new List<ContactsUni2>();
        contactlist.Add(CU);
        return View(contactlist);
    }
    
