    public ActionResult FindRelatedBols(string bolnumber)
    {
        if (bolnumber == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        //var test = 
        //var qrytest = db.Error_Details.Where(r => r.BOL == bolnumber);
        //var details = qrytest.ToList();
        var details = db.Error_Details.Where(r => r.BOL == bolnumber).ToList();
        if (details == null)
        {
            return HttpNotFound();
        }
        return PartialView("~/Views/Error_Details/Index.cshtml", details);
    }
