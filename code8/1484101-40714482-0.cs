    public ActionResult Index(String Page)
    {
    ContactsUnified CU = new ContactsUnified();
    CU.Contattis = db.Contattis.Include(i => i.ContattoID);
    CU.Contacts = db.Contacts;
    CU.Companies = db.Companies;
    List<ContactsUnified> contactlist = new List<ContactsUnified>();
    contactlist.Add(CU.AsEnumerable());
    }
