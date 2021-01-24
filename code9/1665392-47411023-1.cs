    public ActionResult Index(int id)
    {
        var user = Db.Users.FirstOrDefault(x => x.Id == id);
        if(user != null)
        {
            return View(user);
        }
        //Return to the 'Error' view as no user was found
        return View("Error");
    }
