    string FooMyXObject(XObject bar)
        {
           try
           {
               dynamic temp = bar;
               return temp.Value;
           } 
           catch ()
           {
               throw new Exception( "Generic Fail Message" );
           }
        }
