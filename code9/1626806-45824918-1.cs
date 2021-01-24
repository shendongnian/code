    public class SingletonSample
    {
        private SingletonSample()
        {
        }
        private static SingletonSample _instance;
        public static SingletonSample Instance 
         { 
              get
              {
                   if(_instance == null)
                        _instance = new SingletonSample();
                   return _instance;
              }
         }
        public bool IsThisTrue()
        {
            return true;
        }
    }
