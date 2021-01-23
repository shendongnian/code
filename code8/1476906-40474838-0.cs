    [Route("Admin/Users/Edit/{id?}")]
    public ActionResult TestView(int id)
    {
        if (!String.IsNullOrEmpty(id))
        {
            return View(“OneUser”, GetUser(id));
        }
        return View(“AlUsers”, GetUsers());
    }
