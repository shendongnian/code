    public class Rootobject
        {
            public Content content { get; set; }
            public int status { get; set; }
            public string id { get; set; }
            public string method { get; set; }
        }
    
        public class Content
        {
            public string token { get; set; }
            public int is_verified { get; set; }
            public int account_id { get; set; }
            public int is_starter { get; set; }
            public int days_left { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                string json =
                    "{\"content\":{\"token\":\"*************************\",\"is_verified\":1,\"account_id\":45087,\"is_starter\":0,\"days_left\":1},\"status\":200,\"id\":\"test\",\"method\":\"accounts_login\"}";
    
                Rootobject rootobject = new JavaScriptSerializer().Deserialize<Rootobject>(json);
    
                Content content = rootobject.content; // Select what you need
    
                System.Console.ReadKey();
            }
        }
