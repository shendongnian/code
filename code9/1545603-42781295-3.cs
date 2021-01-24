    public class ShowResults
    {
        public string MatchValue { get; set; }
    
        // you can of course add as much properties as you want to be display
        // depending on what information you want to share with the user
    
        public ShowResults(string mv)
        {
            this.MatchValue = mv;
        }    
    }
