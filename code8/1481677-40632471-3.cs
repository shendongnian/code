    public void setMultiAnswer()
    {
    	try
    	{
    		string question = "Question 1"
    		responsesList.Add("Answer1");
    		responsesList.Add("Answer2");
    		questionResponsesList.Add(false);
    		questionResponsesList.Add(true);
    
    		using (Entities testEntity = new Entities())
    		{
    			Question questionObj = new Question();
    			questionObj.Question1 = question;
    			questionObj.CreatedBy = "Test";
    			questionObj.CreatedDate = DateTime.Now;
    			testEntity.Questions.Add(questionObj);
    
    			for (int i = 0; i < responsesList.Count; i++)
    			{
    				// i am not sure about your relation here, but i assume you require one QuestionResponse per response
    				// which is why a moved the line of code
    				QuestionRespons questionResponsesObj = new QuestionRespons();
    				questionObj.QuestionResponses.Add(questionResponsesObj);
    				
    				Response responseObj = new Response();
    				responseObj.Response1 = responsesList.ElementAt(i);
    				responseObj.CreatedBy = "Test";
    				responseObj.CreatedDate = DateTime.Now;
    
    				if (!string.IsNullOrEmpty(responseObj.Response1))
    				{
    					questionResponsesObj.Response = responseObj;
    					questionResponsesObj.CorrectResponse = questionResponsesList.ElementAt(i);
    				}
    
    			}
    			testEntity.SaveChanges();
    		}
    	}
    	catch (Exception ex)
    	{
    		Console.Write(ex);
    	}
    }
