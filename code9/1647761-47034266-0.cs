     [HttpPost]
        public JsonResult yourMethode(model myModel)
        {
         var errorModel = from x in ModelState.Keys where ModelState[x].Errors.Count > 0 select new { key = x, errors = ModelState[x].Errors[0].ErrorMessage };
                    return Json(new { Error = true, Data = errorModel, responseText = "Erreur Model" });
        }
