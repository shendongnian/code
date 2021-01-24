    public static bool IsDebug
    {
      get
         {
          bool isDebug = false;
        #if DEBUG
           isDebug = true;
        #endif
           return isDebug;
          }
    }
