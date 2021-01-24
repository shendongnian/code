    public class Cat {
        public string Name;
        public int Age;
        
        public Cat(string s) { // since I provide a constructor with parameter here, no parameterless constructor exists
            Name = s; 
        } 
    }
    // ...
    void TestCat() 
    {
        // compilation error : 'Cat'' does not contain a constructor that takes 0 arguments
        //var badCat1 = new Cat { Name = "Felix", Age = 3} ;
        //var badCat2 = new Cat() { Name = "Felix", Age = 3} ;
        
        // works (but no way to remove parenthesis here, since there are parameters to pass to csontructor)
        var goodCat = new Cat("Felix") { Age = 3 } ;
        
        Console.WriteLine($"The cat {goodCat.Name} is {goodCat.Age} years old");
    }
