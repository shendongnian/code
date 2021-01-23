    [HttpPost]
    public IActionResult Edit(User user)
    {
  
          _userRepository.Save(user);
          return RedirectToAction(nameof(UserController.Index), "User");
        } 
