      // integer overflow policy (what the system should do if integer value
      // is out of [int.MinValue..int.MaxValue] range) is regulated either explictly
      // by checked/unchecked keywords 
      // or implictly by /checked compiler directive, project settings etc.
      checked { // switch integer overflow check on to ensure OverflowException be thrown
        ...
    
        MyClass c = new MyClass();
     
        c.Counter = int.MaxValue; // maximum possible value
    
        try { 
          c.Counter++; // let's try to add up 1 to maximum possible value
        } catch (Exception ex) {
          // ... And we'll have the exception thrown
          Console.WriteLine(ex.StackTrace); 
        }
    
        ...
      }
