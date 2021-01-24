    @model CodeFirstCustomers.ViewModel.CustomerViewModel
    @using (Html.BeginForm("LoginProcess", "Login"))
    {
        <div class="container">
            <div class="row">
                <div class="col-md-6 col-md-offset-3 alert alert-warning">
                    <div class="row">
                        <div class="col-md-12">
                            ...
                            <button type="submit" class="btn btn-primary">Save</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    }
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public ActionResult Login(CustomerViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Validate crendential here. If valid user, return to Home.
            if (true)
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Incorrect username or password.");
        }
        return View(model);
    }
