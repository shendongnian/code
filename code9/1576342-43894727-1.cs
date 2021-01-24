    public ActionResult Index(string id)
    {
        string SurveyName = "";
        if (id != null)
            SurveyName = id;
        if (!string.IsNullOrEmpty(SurveyName))
        {
            ViewBag.Survey = SurveyName;
        }
        return View();
    }
