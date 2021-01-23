    public ActionResult Test() {
     TempData["shortMessage"] = "MyMessage";
     return RedirectToAction("Details", new { id = theId});
    }
    
    public ActionResult Details {
     //now I can populate my ViewBag (if I want to) with the TempData["shortMessage"] content
      ViewBag.TheMessageIs = TempData["shortMessage"].ToString();
      return View();
    }
