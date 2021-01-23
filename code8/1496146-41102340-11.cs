    [HttpPost]
    public ActionResult Finish(ExamineTest examineTest)
    {
        var question = examineTest.Question.ToList();
        _questions.AddRange(question);
        _testService.SaveSolvedTest(examineTest);
        SolvedTest solvedTest = _testService.GetSolvedTest();
        SolvedTestModel solvedTestModel = EntitySolvedTestConverter.ToModel(solvedTest);
        return Json(new { success = true, htmlElement = View("Finish", solvedTestModel)});
    }
