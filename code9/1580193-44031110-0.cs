    public class Discogs
    {
        public class Pagination
        {
            public int per_page { get; set; }
            public int items { get; set; }
            public int page { get; set; }
    
            public class Urls
            {
                public string last { get; set; }
                public string next { get; set; }
    
            }
    		
    		public Urls urls {get;set;}
    		
            public int pages { get; set; }
    		 
            public class Data
            {
                public string[] style { get; set; }
                public string thumb { get; set; }
                public string[] format { get; set; }
                public string country { get; set; }
                public string[] barcode { get; set; }
                public string uri { get; set; }
    
                public class Community
                {
                    public string have { get; set; }
                    public string want { get; set; }
                }
    			
    			public Community community { get; set; }
    
                public string[] label { get; set; }
                public string catno { get; set; }
                public string year { get; set; }
                public string[] genre { get; set; }
                public string title { get; set; }
                public string resource_url { get; set; }
                public string type { get; set; }
                public string id { get; set; }
            }
    		
            public class Results
            {
                public Data Results { get; set; }
            }
    		
    		public Results result {get;set;}
        }
    	
    	public Pagination pagination {get;set}
    } 
