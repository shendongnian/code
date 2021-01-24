    class Foo
    { 
        private readonly object syncObj = new object();
         public void Blah()
         {
              lock (syncObj)
              {
                  //only one thread at a time
                  //will execute this code
              }
         }
     }
 
