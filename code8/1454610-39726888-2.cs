    public static class MyBaseFactory
    {
         public static MyBase CreateDerivedA()
         {
             int specialPropertyOfA = // ...
             MyBase instance = new DerivedA(specialPropertyOfA);
             Recorder.Process(instance);
             return instance;
         }
         public static MyBase CreateDerivedB()
         {
             string specialPropertyOfB = // ...
             MyBase instance = new DerivedB(specialPropertyOfA);
             Recorder.Process(instance);
             return instance;
         }
    }
