    [HttpPost]
    public async Task<ActionResult> Create(UserCreateUpdateModel model)
    {
       if (ModelState.IsValid)
       {
          var user = new User
          {
             UserName = model.UserName,
             FirstName = model.FirstName,
             LastName = model.LastName
          };
    
          await _userService.AddUserAsync(user);
          return RedirectToAction("List");
        }
        return View("Create", model);
    }
