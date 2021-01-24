    [HttpPost]
    public ActionResult StaffRegistration(StaffRegistrationViewModel model)
    {
        // other logic here
        // enum assignment example
        Gender? gender = model.GGender;
        
        // other logic here
        return View(model);
    }
