    [HttpPost]
    public void SecondAction(string lastname) {
        Session["lastname"]=lastname;
    }
    public ActionResult ThirdAction () {
        string fullname;
        fullname = string.Format((string)Session["name"] + 
        (string)Session["lastname"]);
        return View(fullname);
    }
