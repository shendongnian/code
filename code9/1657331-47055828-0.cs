    class Person
     {
    
     private string name;  // the name field
    
      public string Name    // the Name property
  
      {
      
      get
          
       {
         
      return name;
       
       }
       
       set
       
       {
         
       name = value;
       
       }
         }
             }
                 When you assign a value to the property, the set accessor is 
         invoked by using an argument that provides the new value. For example:
        Person person = new Person();
       person.Name = "Joe";  // the set accessor is invoked here                
      System.Console.Write(person.Name);  // the get accessor is invoked here
   
      It is an error to use the implicit parameter name, value, for a local 
            variable declaration in a set accessor.
