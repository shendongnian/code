      public JsonResult GetCityList(int? Id)
      {
        var citylist = _userService.GetAllCity().Where(p => p.StateId == Id).ToList();
         IEnumerable<SelectListItem> selectList = from s in citylist
                                                             select new SelectListItem
                                                             {
                                                                 Value = Convert.ToString(s.Id),
                                                                 Text = s.Name
                                                             };
         return Json(new SelectList(selectList, "Value", "Text"), JsonRequestBehavior.AllowGet);
       }
