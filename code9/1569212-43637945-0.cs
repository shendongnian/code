    public class wrapper {
       private ClassA objA;
       private ClassB objB;
       public wrapper(ClassA obj)
       {
          objA=obj;
       }
    
       public wrapper(ClassB obj)
       {
          objB=obj;
       }
    
       public int? Property1 
       { 
          get 
          { 
             return objA?.Property1 ?? objB?.Property1; 
          } 
       } 
    }
