    // GET: /Manage/Users
    public async Task<ActionResult> Users()
    {
        if (await HttpContext.AuthorizePermission(name: "AllUsers_Management", description: "Edit all of the users information."))
        {
            return View(db.GetAllUsers());
        }
        else if (await HttpContext.AuthorizePermission(name: "UnConfirmedUsers_Management", description: "Edit unconfirmed users information."))
        {
            return View(db.GetUnConfirmedUsers());
        }
        else
        {
            return View(new List<User>());
        }
    }
