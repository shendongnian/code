    public class MainModel
    {
        public UserML userLM {get;set;}  // note { get;set; }
    
        public Search search {get;set;}
     
         public MainModel()
         {
            userLM = new UserML();
            search = new Search();           
        }
    }
