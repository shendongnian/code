       public class SessionQuestionResultModel
        {
            public int Id { get; set; }
    
            public int SessionQuestionId { get; set; }
    
            public SessionQuestionModel SessionQuestion { get; set; }
        }
    
    
        public class SessionFeedbackModel
        {
            public int Id { get; set; }
            public int SessionId { get; set; }
    
            public SessionModel Session { get; set; }
    
        }
