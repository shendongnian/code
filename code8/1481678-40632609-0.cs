        Question questionObj = new Question
        {
            Text = question,
            CreatedBy = "Test",
            CreatedDate = DateTime.Now
        };
        
        foreach(var response in responsesList.Where(x => !string.IsNullOrEmpty(x)))
        {
            Response responseObj = new Response
            {
                Text = response,
                IsCorrect = true,
                CreatedBy = "Test",
                CreatedDate = DateTime.Now
            }
            
            questionObj.Add(responseObj);
        }
        testEntity.Questions.Add(questionObj);
        testEntity.SaveChanges();
