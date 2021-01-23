    public ActionResult CheckTagName(int SeqNumber)
    {
      var exist= !db.Projects.Any(g => g.SeqNumber == SeqNumber);
      return Json(exist,JsonRequestBehavior.AllowGet);
    }
