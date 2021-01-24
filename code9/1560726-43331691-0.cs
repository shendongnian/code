    [HttpPost]
    public async Task<ActionResult> Edit(UserViewModel model)
    {
       if (ModelState.IsValid)
       {
          var user = await _userService.GetUserByIdAsync(model.Id);
          if (user == null)
          {
              return RedirectToAction("List");
          }
    
          user.FirstName = model.FirstName;
          user.LastName = model.LastName;
          user.Active = model.Active;
          user.ModifiedOn = _dateTime.Now;
          user.ModifiedBy = _webUserSession.UserName;
          await _userService.UpdateUserAsync(user);
    
          return RedirectToAction("List");
       }
       return View("Edit", model);
    }
