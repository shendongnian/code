    [HttpPost]
    public ActionResult Finish(ExamineTest examineTest)
    {
        return Json(new { success = true, htmlElement = RedirectToAction("Preview", "Test")});
    }
