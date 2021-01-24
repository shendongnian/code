    ViewData["viewdataQuarterName"] = new SelectList(db.QuarterName, "QuarterID", "QuarterName1"); 
            [HttpPost]
        public ActionResult Action(string QuarterID)
        {
            var query = from c in db.QuarterName
                        where c.QuarterId.ToString() == QuarterID
                        select c;
            return Json(query);
        }
