    var myVar = new MyClass(nameof(myVar));
    var var2 = myVar;
    var2.GetName(); // returns "myVar"
    
    public class MyClass {
        public MyClass(name){
            this.createdWithName = name; 
        }
        public string GetName(){
            return this.createdWithName;
        }
    }
