    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateQuestion([Bind(Include="AnswerA,AnswerAVote,AnswerB,AnswerBVote,GroupID,GroupItemID,Question")] QuestionObject questionObject)
    {
        if (ModelState.IsValid)
        {
            _context.QuestionObjects.Add(questionObject);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(questionObject);
    }
