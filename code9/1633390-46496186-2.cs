    [HttpPost]
    public ActionResult Finish([Bind(Include = "propertyName1,propertyName2,propertyName3")] Student model, string finish)
    {
        if (ModelState.IsValid)
        {
            try {
                //do your logic here
                return RedirectToAction("StudentRecord");
            } catch (Exception ex) {
                TempData["errorMessage"] = "Error: " + ex.Message + " - " + ex.InnerException;
                //ViewBag.errorMessage = "Error: " + ex.Message + " - " + ex.InnerException;
                return View(model);
            }
        }
        else
        {
            TempData["errorMessage"] = "Error: Please fill the form correctly";
            return View(model);
        }
    }
