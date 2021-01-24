    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateQuestion([Bind("AnswerA,AnswerAVote,AnswerB,AnswerBVote,GroupID,Question")] QuestionObject questionObject)
    {
    	if (ModelState.IsValid)
    	{
    		questionObject.GroupItem = _context.GroupItem.Single(m => m.GroupItemID == questionObject.GroupItemID)
    		_context.Add(questionObject);
    		await _context.SaveChangesAsync();
    		return RedirectToAction("Index");
    	}
    	return View(questionObject);
    }
