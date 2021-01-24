     if(Monitor.TryEnter(lockObj)) {
      try {
        //does something
        if(failing_condition) {      
          throw new Exception("Oops!");
        }
      }
      finally {
        Monitor.Exit(lockObj);
      }
    }
