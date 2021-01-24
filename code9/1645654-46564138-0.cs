    private static List<Contact> contactList = new List<Contact> 
    {
        new Contact(1, "John", 10),
        new Contact(2, "Joe", 20),
        new Contact(3, "Jake", 30)
    };
    
    public ActionResult Index()
    {
      return View(contactList);
    }
    
    // GET: Contact/Details/5
    public ActionResult Details(int id)
    {
      Contact contact = contactList.FirstOrDefault(x => x.Id == id);
      return View(contact);
    }
