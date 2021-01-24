    [HttpPost]
    public void Post([FromBody]PostInput input)
    {
         SaveQuestion obj = new AllDataAccess.controller.SaveQuestion();
         obj.savaData(question);
    }
