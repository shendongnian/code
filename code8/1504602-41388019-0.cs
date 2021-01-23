    public ActionResult index(string searchBy, string searchFirstName, string searchLastName)
    {
        if (searchBy == "name")
        { 
            return View(db.members.Where(x => x.members_firstname.Contains(searchFirstName) 
                                           && x.members_lastname.Contains(searchLastName)).ToList());
        }
    }
