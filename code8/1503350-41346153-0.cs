    public class MyClass{
        public string A{get; set;}
        public List<int> B{get; set;}
     }
                    
    string js= "{"A" : "1","B" : [1,2,3,4,5,6]}";
                        
    MyClass obj  = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<MyClass>(js);
                    
    obj.B= obj.B.Where(t => t % 2 == 0).ToList();
