    public class Example
        {
            public bool Status { get; set; }
            public ResultModel ResultModel { get; set; }
            public bool Error { get; set; }
    
            public Example()
            {
                ResultModel = new ResultModel();
            }
        }
    
        public class ResultModel
        {
            public int ID { get; set; }
            public int UserId { get; set; }
            public int WebId { get; set; }
        }
