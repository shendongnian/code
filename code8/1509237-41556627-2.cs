       public ActionResult Index()
            {
                ViewBag.CountryID = new SelectList(db.Countries, "ID", "Name", "34");
    .....
       public JsonResult GetState(int? id)
            {
                if (id == null)
                {   id = 34;  }
                var data =   db.States.Where(x => x.CountryID == id)
                        .Select( x =>
                                new
                                {
                                    ID = x.ID,
                                    Name = x.Name
                                }).ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
