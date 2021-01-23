    [Route("Admin/Users/Edit/{id?}")]
    public ActionResult TestView(string id)
    {
        if (!string.IsNullOrEmpty(id))
        {
            return View(“OneUser”, GetUser(id));
        }
        return View(“AlUsers”, GetUsers());
    }
