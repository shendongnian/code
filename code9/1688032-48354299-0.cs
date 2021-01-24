    [HttpGet]
    public IActionResult EditUser() {
        var model = new Users();
        return View(model);
    }
    
    [HttpPost]
    public IActionResult EditUser(Users u) {
        if (!ModelState.IsValid) {
            return View(u);
        }
        UsersDAL ud = new UsersDAL();
        ud.Edit(u);
        return RedirectToAction("ShowUsers", "ControllerName");
    }
    
    public IActionResult DeleteUser(Username u) {
        if (!ModelState.IsValid) {
            return View(u);
        }
        UsersDAL ud = new UsersDAL();
        ud.Delete(u);
        return RedirectToAction("ShowUsers", "ControllerName");
    }
