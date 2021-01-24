    [HttpPost]
    public ActionResult Edit(UserProfile model)
    {
        if(User.Identity.GetUserId() != model.ApplicationUser.Id)
            return new HttpUnauthorizedResult();
        ...
    }
