    public class OuterClass {
    
        public static void main(String[] args) {
    
            // Creates a reference of our outer class
            NewClass myClass = new OuterClass();
    
            // Uses it to create an instance of the nestled class
            OuterClass.Nested nested = OuterClass.new Nested();
    
            // Uses the nestled class object to instantiate an inner nestled object
            OuterClass.Nested.InnerNested inner = nested.new InnerNested();
    
        }
        
        
        class Nested {
    
            public class InnerNested {      }
    
        }
    }
