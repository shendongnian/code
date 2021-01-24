    namespace AskYourQuestion
    {
        public struct QuestionNum
        {
            public string Q1;
        }
    
        class Questions
        {
            QuestionNum pq = new QuestionNum();
            // pq.Q1 = "hi"; --> This will not work
            // Why? See below        
        }
    }
