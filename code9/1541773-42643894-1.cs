            public ActionResult GeneratePDFforSignature(int? id)
                {
                  \\check id is null
                    if(id!=null)
                    {
                        Signature signature = db.SignatureDatabase.Find(id);
                       \\check signature is null
                        if(signature!=null)
                          {
                            return View();
                        }
                   
                     }
                       return RedirectToAction("ErrorPage")   
                }
        
      //  or
        public ActionResult GeneratePDFforSignature(int? id)
                {
                  try
                    {
                         Signature signature = db.SignatureDatabase.Find(id);
                           //do something with signature
                         return View();
                    }
                    catch (NullReferenceException ex){
                     return RedirectToAction("ErrorPage")  
                    }
                       
                }
        
                    
