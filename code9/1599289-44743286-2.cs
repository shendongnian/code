    public class Parent {
           // some thing at here
           private readonly SubClass sc;
           
    
           // ctor
           public Parent () {
                  sc = new SubClass();
           }
           
    
           public string foo () {
                 return sc.bar();
           }
          
    
           private class SubClass {
                 // have some thing here
                public string bar() {
                     //..............
                     return "...........";
                }
           }
    }
