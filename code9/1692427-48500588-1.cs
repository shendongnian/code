    public class Cat {
        public string Name;
        
        public Cat(string s) { // since I provide a constructor with parameter here, no parameterless constructor exists
            Name = s; 
        } 
    }
    // ...
    void myTest() 
    {
        // compilation error : 'Cat'' does not contain a constructor that takes 0 arguments
        var cat = new Cat { Name = "Felix", } ;
    }
