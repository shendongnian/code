      private string _rand; 
      public static MyClass Instance
        {
            get
            {
                lock (locked)
                {
                    if (instance == null)
                    {
                        instance = new MyClass();
                        rand = return new Random().Next(2500).ToString();
                         
                    }
                }
    
                return instance;
            }
        }
    public string Rand {
     get {
         return _rand;
     }
    }
