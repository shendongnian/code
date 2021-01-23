    public ActionResult Index() {
    string currentUserId = User.Identity.GetUserId();
    var currentUser = db.Users.FirstOrDefault( x => x.Id == currentUserId );
    List<Seen> seens = new List<Seen>();
    if( db.Announcements != null ) {
       foreach( Announcement anoun in db.Announcements ) {
          seens.Add(
          new Seen
          {
             User = currentUser, // You have this already so why go to the database again?
             Announcement = anoun, // Same with this.
          });
    
       }
    }
    
    // Save seens to the database
    
    return View( db.Announcements.ToList() );
