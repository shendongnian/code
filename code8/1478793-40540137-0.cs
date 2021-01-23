    [HttpPost]
    public ActionResult Profiles(UserProfile model)
    {
        try
        {
            _userRepository.UpdateUserProfile(model);
            TempData["Message"] = "Success";
            return RedirectToAction("Profiles",new { id= model.Id });
        }
        catch
        {
            ModelState.AddModelError(string.Empty,"Some error happened");
            return View(model);
        }
    }
