    public ActionResult(Model m , string User )
    {
      var user = db.Users.Find(User)
      var model = new Model 
       {
          User =user,
          etc, 
          etc...
       }
    }
