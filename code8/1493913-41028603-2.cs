    void Something(){
      ....
      if(ExecuteWithRetry(()=>NotTrustyMethod(), 2)) {
         //success
      } else {
         //fail
      }
      
    }
    void NotTrustyMethod(){ ...}
