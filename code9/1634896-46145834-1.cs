    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult ReferralConfirmation(ReferrerInstanceViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
           //to do : Your code before the redirect goes here
            return RedirectToAction("RedirectToAction", 
                                             new { referralId = viewModel.ReferralId });
        }
        //model validation failed. Let's return to same view
        return View(viewModel);
    }
