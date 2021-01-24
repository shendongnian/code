     public ActionResult EntranceInspectionResult()
        {
            EntranceInspection s = new EntranceInspection();
            s.p1_notice = Request["p1_notice"]; // to SQL - ok
            s.p1_t1 = Convert.ToDateTime(Request["p1_t1"]); 
            d.EntranceInspection.InsertOnSubmit(s);
            d.SubmitChanges();
            return View("EntranceInspection");
        }
