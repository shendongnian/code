    public class obj 
                    {
                    public DateTime updated {get;set;}
                    public string id {get;set;}
                    public string Name {get;set;}
                     public self links {get;set;}
                    public string FacebookId {get;set;}
                    public int highscore {get;set;}
                    
                    }
        
        public class self {
        public string href {get;set;}
        public string title {get;set;}
                       }
                    
                    var dic = new Dictionary<TKey, obj>();
                    var sorted = dic.OrderBy(x=>x.Value.highscore).ToList();
