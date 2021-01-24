       public JsonResult GetEmployeeNameByKeyword(string SearchedString)
        {
			List<UserProfile> EmployeeNames = new List<UserProfile>();
            EmployeeNames = _db.UserProfiles.Where(i => i.UserNames.Contains(SearchedString)).ToList();
            return Json(EmployeeNames, JsonRequestBehavior.AllowGet);
        }
