    public class MyResponse {
        public int Id {get; set;}
        public string Name {get; set;}
        public string ApplicationID {get; set;}
        public IList<MyFeature> Features {get; set;}
    }
    
    public class MyFeature {
        public int Id {get; set;}
        public string Name {get; set;}
        public int ProductId {get; set;}
        public string Selected {get; set;}
    
    } 
