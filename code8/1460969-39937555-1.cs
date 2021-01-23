    public ActionResult CreateEvent() {
        var model = new CreateNewEventModel();
        //...FILL MODEL
        foreach (var user in db.UsersInfo.ToList()) {
            model.CheckBoxDataItems.Add(new CheckBoxItem() {
                UserId = user.Id,
                Name = user.Name,
                Data = 0,
                Selected = false
            });
        }
        // THERE IS FULL MODEL
        return View(model);
    }
