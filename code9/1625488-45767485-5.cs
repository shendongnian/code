    using something;
    using someotherthing;
    using SubNamespace; //add the namespace
    
    namespace MyMainNamespace
    {
       private class MyMainClass
       {
          private void blahblah {
          ... 
          // Now you can use methods & functions that exist in `SecondaryClass`
          SecondaryClass secondary = new SecondaryClass();
          secondary.apple(); 
          ....
          ....
          }
       }
    }
