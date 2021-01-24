    class A
    {
      public List<object> AList {get;set;}
    }
    
    class B
    {
      private A localInstance;
      public B(A instance)
      {
        localInstance = instance;
      }
      
      public void SomeMethod()
      {
         // access to list from instance of A
         var a = localInstance.AList
      }
    }
    
    // Similar implementation for class c
