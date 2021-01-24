    public JsonResult Files(//parameters...)
    {
    //...some code
      System.Web.HttpContext.Current.Session["FileInBytes"] = bytesArray; //fileBytes is an array of bytes
      System.Web.HttpContext.Current.Session["FileName"] = fileName;;  
    }
    public ActionResult DisplayFile()
    {
       var fileInBytes = Session["FileInBytes"] as byte[];
       var fileName = Session["FileName"] as string;
       Session.Remove("FileInBytes");
       Session.Remove("FileName"); 
    }
