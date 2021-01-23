    public ActionResult SomeAction()
    {
  
       HotelManagementEntities db = new HotelManagementEntities();
       
       ViewBag.Category = new SelectList(db.tblCategories, "intseqid", "varCategory");
    }
