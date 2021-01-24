    public class MyAttribute : System.Attribute
    {
        bool Reviewed { get; set; }
        bool HasTestSuit { get; set; }
        
        public MyAttribute(bool hasReviewed,bool hasTestSuite)
        {
                this.Reviewed = hasReviewed;
                this.HasTestSuit  = hasTestSuite;
        }   
    }
