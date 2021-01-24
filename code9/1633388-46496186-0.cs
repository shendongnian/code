    [HttpPost]
    public ActionResult Finish(Student model, string finish)
    {
        if (ModelState.IsValid)
        {
            try {
                //do your logic here
                return RedirectToAction("StudentRecord");
            } catch (Exception ex) {
                TempData["errorMessage"] = "Error: " + ex.Message;
                return View(model);
            }
        }
        else
        {
            TempData["errorMessage"] = "Error: Please fill the form correctly";
            return View(model);
        }
    }
