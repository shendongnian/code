    public ActionResult GetFaculties(int u)
    {
        var facultyList = db.Fakulteler.Where(a=>a.id_uni==u)
                            .Select(x=>new SelectListItem { Value=x.Id,
                                                           Name=x.Name).ToList();
        return Json(facultyList , JsonRequestBehavior.AllowGet);
    }
