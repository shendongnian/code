	[HttpPost]
	public void Post([FromBody]string question)
	{
		 SaveQuestion obj = new AllDataAccess.controller.SaveQuestion();
		 obj.savaData(question);
	}
