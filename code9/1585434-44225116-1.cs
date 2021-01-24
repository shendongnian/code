    public static Singleton getInstance()
    {
       // Return the instance we might have stored earlier.
       if (singleton != null)
          return singleton;
    
       // Now we store the only instance that will ever be created.
       singleton = new Singleton();
       return singleton;
    }
