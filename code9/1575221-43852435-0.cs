    public ActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public ActionResult FileUpload(HttpPostedFileBase file)
    {
        Debug.WriteLine(file.FileName)
        if (file != null)
        {
             var fileName = Path.GetFileName(file.FileName);
             pathName = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
             file.SaveAs(pathName);
         }
        return changeText(txt);
     } 
     public ActionResult changeText (string text)
     {
          return ResultX(textChange);               
     }
     public ActionResult ResultX(string text)
     {
          return View("ResultX", text);
     }
