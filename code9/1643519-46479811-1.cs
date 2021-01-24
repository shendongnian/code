    public class World{ 
        public MyDoubles MyDoubles { get; set; } = new MyDoubles(); // initialized by default
        public MyStrings MyStrings { get; set; } = new MyStrings(); // initialized by default
        .....
    }
    public class MyDoubles {
       public Double a {get;set;}
       public Double b {get;set;}
       public Double c {get;set;}
       //.... 
    }
    public class MyStrings {
       public String a {get;set;}
       public String b {get;set;}
       public String c {get;set;}
       //.... 
    }
