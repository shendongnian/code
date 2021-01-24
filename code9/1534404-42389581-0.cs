    public class MyResponse {
        public string id {get;set;}
        public string name {get;set;}
        public string email {get;set;}
        public List<friend> friends {get;set;}
        
        public class friend{
            string id {get;set;}
            string name {get;set;}
        }
    }
