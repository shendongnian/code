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
                    return Json(new { Message="Company added successfully"});
                }
           }          
           return Json(new { Message="Validation errors!"});
       }
       catch(Exception ex)
       {
           // must log the exception
           return Json(new { Message="Error "});
       }    
     }
