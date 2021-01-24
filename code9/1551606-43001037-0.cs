    [HttpPost]
    public ActionResult Index(string ViewSubject)
    {
        var g = GradeService.GetExamGradesToUpdate(ViewSubject);
        // do something with g
        // to do : Return something
    }
