    [HttpPost]
    public ActionResult Save(HttpPostedFileBase productIcon,
                                                IEnumerable<HttpPostedFileBase> productImages)
    {
      // to do : Save these
      if(productIcon!=null)
      {
        // to do : Save icon image 
      }
      if(productImages!=null)
      {
         foreach(var img in productImages)
         {
           // to do : Save img
         } 
      }
      // to do : Return something
    }
