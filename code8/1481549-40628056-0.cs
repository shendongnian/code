    public ActionResult ChangeUsername(int userId)
    {
        // Clear any old model state info
        ModelState.Clear();
        // get the current username
        var viewModel = new ChangeUserNameViewModel
        {
            UserId = userId,
            UserName = username
        };
        return View(viewModel);
    }
