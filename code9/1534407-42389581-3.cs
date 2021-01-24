    public class MyResponse {
        public string id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public friend friends { get; set; }
        
        public class friend{
            public List<data> data {get;set;}
            public class data {
                string id {get;set;}
                string name {get;set;}
            }
        }
    }
