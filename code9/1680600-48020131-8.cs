    [HttpPost]
    public void Post(string question)
    {
         SaveQuestion obj = new AllDataAccess.controller.SaveQuestion();
         obj.savaData(question);
    }
