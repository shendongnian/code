    [HttpPost]
    public ActionResult Save(HttpPostedFileBase iconImg,
                                                  IEnumerable<HttpPostedFileBase> otherImages)
    {
      // to do : Save these
      if(iconImg!=null)
      {
        // to do : Save icon image 
      }
      if(otherImages!=null)
      {
         foreach(var img in otherImages)
         {
           // to do : Save img
         } 
      }
      // to do : Return something
    }
