    [HttpPost]
    public ActionResult Edit(int id, Client cmodel)
    {
       try
       {
          ClientManagement cdb = new ClientManagement();
          if (cdb.UpdateDetails(cmodel))
          {
             TempData["Message"] = "Client Details Edited Successfully";
          }
          return RedirectToAction("Profil");
       }
       catch
       {
          return View(cmodel);
       }
    }
