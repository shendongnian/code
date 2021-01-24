    public Class MyClass : MonoBehaviour {
    
    
        // Delegates, like a pointer in C, but to method(s) instead of variable
            public delegate void valueLogsChangedDelegate (int valueLogs);
            public valueLogsChanged valueLogsChanged = delegate { };
    
    
        private int _numberOfLogs;
    
    // Property, when you set numberOfLogs (eg numberOfLogs = 10), every thing in "set" is executed
        public int numberOfLogs {
            get {
                return _numberOflogs;
            }
            set {
                _numberOfLogs = value;
                valueLogsChanged(_numberOflogs);
            }
    
        }
    
      /// <summary>
      /// Awake is called when the script instance is being loaded.
      /// </summary>
      void Awake()
      {
          // Subscribe to the delegate, you can add as many methods as you want. Every methods that subscribe to the delegate will be excuted when the delegate is called
          valueLogsChanged += Method;
      }
    
      void Method(int valueLogs)
      {
          if (valueLogs > 5)
          {
              jumpPower = 2000;
          }
      }
    
    }
