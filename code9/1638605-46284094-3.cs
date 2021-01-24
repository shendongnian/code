    [HttpPost]
    public ActionResult AddCompany(MainModel mainModel)
    {    
        try
        {
           if (ModelState.IsValid)
           {
                dp obj = new dp();
                if (obj.AddNewCompany(mainModel))
                {
                    TempData.Message = "Company added successfully";
                    return RedirectToAction("CompanyList");
                }
           }
           // We need to repopulate the data needed for rendering dropdown
           Country_Bind();
           return View(mainModel);
       }
       catch(Exception ex)
       {
          // to do : Make sure to log the error
          return View("Error");
       }    
     }
