    public ActionResult AddGroupsQty()
    {
      int qty=0;
      string subjectName=string.Empty;
      if(TempData["qty"]!=null)
      {
        qty = Convert.ToInt32(TempData["qty"]);
      }
      if(TempData["subject"]!=null)
      {
        subjectName = TempData["subject"];
      }
      // Use this as needed
      return View();
    }
