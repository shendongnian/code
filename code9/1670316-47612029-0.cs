     private ApplicationUserManager _userManager;
              public ApplicationUserManager UserManager
            {
                get
                {
                    return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                }
                private set
                {
                    _userManager = value;
                }
            }
    
    var user =  UserManager.FindById(User.Identity.GetUserId());
    var userId = Guid.Parse(user.Id);
    
    var _context = new MessageContext();               
    var myContacts = _context.Contacts.Where(c => c.CustomerId == userId).ToList();
                     ViewBag.Contacts = myContacts;
