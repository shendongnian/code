    public class OKStatus{
        public int HTTPStatusCode {get; set;}
        public FeedBack[] objFeedBackManagmentViewModel {get; set;}
    }
        
    public class FeedBack{
        public int ID {get; set;}
        public string FeedBackDetail {get; set;}
        public DateTime CreateDate {get; set;}      
    }
