    [HttpPost]
    public ActionResult CheckCondition(FormCollection form)
    {
        if (someConditionCodeGoesHere==false)  // replace this with your condition code
        {
            return View();
        }
        else 
        {
            return RedirectToAction("Success");
        }
    }
    public ActionResult Success()
    {
       return View();
    }
