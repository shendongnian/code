    public class Class3
      {
        private bool _initCalled = false;
        public void Initialize()
        {
          if (!_initCalled)
          {
            lock (this)
            {
              // we need to insert an empty DummyMethod here
              DummyMethod();
              if (_initCalled)
                return;
              NoConfigInit();
              _initCalled = true;
            }
          }
        }
    
        private void DummyMethod()
        {
          // This method stays empty in production code.
          // It provides the hook for the unit test.
        }
    
        private void NoConfigInit()
        {
    
        }
     }
