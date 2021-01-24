    [HttpPost]
    public ActionResult rb(subject sj, FormCollection frm)
    {
        if (ModelState.IsValid)
        {
            var selectsubj = sj.selectsubj;
            string getcode = frm["subj"];
            ViewBag.ssss = getcode;
            return View("view_with_textbox");
        }
        return View("Index");
    }
