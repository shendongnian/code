    public JsonResult GetCityList(int? Id = 0)
            {
                var Citylist = _masterService.GetAllCity().Where(p => p.StateId == Id).ToList();
                return Json(new SelectList(Citylist.ToArray(), "Id", "Name"), JsonRequestBehavior.AllowGet);
            }
