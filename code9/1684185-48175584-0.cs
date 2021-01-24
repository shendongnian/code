    public class UpdateCarrierQuestionMapsWebRequests
    {
        public List<UpdateCarrierQuestionMapsWebRequest> Updates { get; set; }
        public UpdateCarrierQuestionMapsWebRequests()
        {
           Updates = new List<UpdateCarrierQuestionMapsWebRequest>();
        }
 
       public class UpdateCarrierQuestionMapsWebRequest
       {
            public string CarrierStateMapGuid { get; set; }
            public string QuestionTag { get; set; }
            public string MemberOf { get; set; }
            public string Condition { get; set; }
            public string QuestionType { get; set; }
            public string TrueAnswer { get; set; }
            public string TrueExplanation { get; set; }
            public string FalseAnswer { get; set; }
            public string FalseExplanation { get; set; }
            public bool DeleteRequest { get; set; }
        }
    }
