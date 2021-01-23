     public ActionResult Register()
     {
        List<DistrictModel> districtModelList = db.DistrictModel.ToList();
        ViewData["DistrictNameList"] = districtModelList.Select(x => new SelectListItem { Value = x.Id , Text = x.DistrictName  });
        return View();
     }  
