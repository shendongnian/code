    [HttpPost]
    public ActionResult rb(subject sj, FormCollection frm)
    {
        if (ModelState.IsValid)
        {
            var selectsubj = sj.selectsubj;
            string getcode = frm["subj"];
            
            var model = new ATM.Models.subject()
            {
                selectsubj = getcode
            };
            return View("view_with_textbox", model);
        }
        return View("Index");
    }
