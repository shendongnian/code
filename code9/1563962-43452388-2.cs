    private void Method(BaseClass base) {
         var sub1 = base as Sub1;
         var sub2 = base as Sub2;
         
         if(sub1 != null) {
               // do something specific
         }
         if(sub2 != null) {
               // do something specific
         }
         else
              throw new SubTypeIsNotSupportedException();
    }
