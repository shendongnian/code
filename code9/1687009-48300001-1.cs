    [HttpPost]
    public ActionResult AddUser(Users u)
    {
        if (!ModelState.IsValid)
        {
            return View(u);
        }
        UsersDAL ud = new UsersDAL();            
        ud.Insert(u);
        return RedirectToAction("Index", "Home"); // redirects to ../Home/Index
    }
