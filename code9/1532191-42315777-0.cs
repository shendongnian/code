        public JsonObject GetJson_1()
        {
            var errors = new Dictionary<string, string>();
            errors.Add("Id", "invalid");
            return new JsonObject(errors);
        }
        public ActionResult GetJson_2()
        {
            var errors = new List<object>();
            errors.Add(new { Id = "invalid" });
            return Json(errors, JsonRequestBehavior.AllowGet);
        }
