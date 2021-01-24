      ManualResetEventSlim m_Condition = new ManualResetEventSlim(false);
      public bool Condition {
        get {
          return m_Condition.IsSet;  
        }
        set {
          if (value) 
            m_Condition.Set();
          else
            m_Condition.Reset();
        }
      } 
      ...
      Task myTask = Task.Run(() => {
        m_Condition.Wait();
        ...
      });
