       public HttpResponseMessage SendQuestionDetails([FromBody] Dictionary<string, QuestionDetails> UserDetailInput)
            {
       List<Questions> list = new List<Questions> { };
                list.Add(new Questions
                {
                    CorrectOption = "CorrectOption1",
                    OptionA = "OptionA1",
                    OptionB = "OptionB1",
                    OptionC = "OptionC1",
                    OptionD = "OptionD1",
                    QuestionCategory = "QuestionCategory1",
                    QuestionText = "QuestionText1"
                });
                list.Add(new Questions
                {
                    CorrectOption = "CorrectOption2",
                    OptionA = "OptionA2",
                    OptionB = "OptionB2",
                    OptionC = "OptionC2",
                    OptionD = "OptionD2",
                    QuestionCategory = "QuestionCategory2",
                    QuestionText = "QuestionText2"
                });
    
                Dictionary<QuestionDetails, int> dictionary = new Dictionary<QuestionDetails, int> { };
                QuestionDetails detail = new QuestionDetails { lstQuestions = list, Status = 1 };
    
                HttpResponseMessage mesage = Request.CreateResponse(HttpStatusCode.OK, detail);
                return mesage;
        return mesage;
        }
