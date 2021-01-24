    public JsonResult GetAllCICO(string SSN)
        {
            var cicos = GetCICO().ToList();
            var jsonResult = Json(new{data = cicos}, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
