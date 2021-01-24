      public ActionResult Index()
      {
        if(TempData.ContainsKey("JSON") && !string.IsNullOrEmpty((string)TempData["JSON"]))
        {
           ViewBag.JSON = System.IO.File.ReadAllText((string)TempData["JSON"]);
        }
            return View();
      }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            // Verify that the user selected a file
            if (file != null && file.ContentLength > 0)
            {
                // extract only the filename
                var fileName = Path.GetFileName(file.FileName);
                // store the file inside ~/App_Data/uploads folder
                var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                TempData["JSON"] = path;
                file.SaveAs(path);
            }
             
            // redirect back to the index action to show the form once again
            return RedirectToAction("Index");
        }
