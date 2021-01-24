    public class MyJson {
     public class MyRequest request {get ;set;}
    }
    
    public class MyRequest {
     public string md5 {get;set;}
     public string file_name {get;set;}
     public string file_type {get;set;}
     public List<string> features {get;set;}
     public MyTe te {get;set;}
    }
    public class MyTe {
        public List<string> reports {get;set;}
        public List<MyImages> images {get;set;}
    }
    public class MyImages {
        public string id {get;set;}
        public int revision {get;set;}
    }
