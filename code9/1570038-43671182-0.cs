     public ActionResult DeleteDetail(SampleHeaderViewModels objHeader, 
      List<SampleDetailViewModels> objDetail, int intLine)
      {
         ...
      ...
      db.SaveChanges();
      return Json(new { Success = true; });
      }
