     public class Rootobject
     {         
        public Class1[] Property1 { get; set; }
     }
    
        
     public class Class1
     {
        public int ID { get; set; }
    
        public string Code { get; set; }
    
        public string Name { get; set; }
     }
         string jsonResponse = "{ \"Property1\" :  [{\"ID\":1,\"Code\":null,\"Name\":\"Black\"},{\"ID\":1,\"Code\":null,\"Name\":\"Red\"},{\"ID\":1,\"Code\":\"blx\",\"Name\":\"Blue\"}] }";
                       
         var result = (new JavaScriptSerializer()).Deserialize<Rootobject>(jsonResponse);
