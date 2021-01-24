    public static Singleton getInstance()
    {
       // "singleton" will always be null.
       if (singleton != null)
       {
          return singleton;
       }
    
       // Always returns new instance rather than existing one.
       return new Singleton();
    }
