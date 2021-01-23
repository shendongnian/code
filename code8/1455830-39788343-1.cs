           [HttpPost]
          public ActionResult Edit(UploadData uploadData)
          {
              if (!ModelState.IsValid)
              {
                  return View(uploadData);
              }
        else  {
                    TempData["ErrorMsg"] = "";
                          foreach (var items in ModelState.Values)
                          {
                              foreach (var er in items.Errors)
                              {
                                    
                               TempData["ErrorMsg"] = er.ErrorMessage.ToString() " " + TempData["ErrorMsg"].ToString();
                                }
                                
                            }
                            return View(uploadData);
                        }
        }
     
       
   
