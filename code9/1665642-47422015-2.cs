    namespace AskYourQuestion
    {
        public struct QuestionNum
        {
            public string Q1;
        }
    
        class Questions
        {
            internal QuestionNum pq = new QuestionNum() { Q1 = "Hi" };
    
            public Questions()
            {
            }
    
            public Questions(string defaultValue)
            {
                this.pq.Q1 = defaultValue;
            }
        }
    }
