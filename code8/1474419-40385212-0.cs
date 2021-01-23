    public ActionResult UserDetails(int? id)
    {
        if (!id.HasValue)
            return View("UserNotFound"); // Or return a message.
    
        int userId = id.Value; 
        var user = _userService.GetUserById(userId);
        // Do something
    }
