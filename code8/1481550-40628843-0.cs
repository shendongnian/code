    public ActionResult ChangeUsername(int userId)
    {
        // get the current username
        var viewModel = new ChangeUserNameViewModel
        {
            UserId = userId,
            UserName = username
        };
        ModelState.Clear();
        return View(viewModel);
    }
