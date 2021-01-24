    public static T SafeProcessing<T>(Action<T> action, Action<T> onFail)
        where T: new()
    {
         var t = new T();
         
         try
         {
             a(t);
         }
         catch (Exception e)
         {
              //Log e
              onFail(t);
         }
         return t;
     }
