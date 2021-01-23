      // integer overflow policy (what the system should do if integer value
      // is out of [int.MinValue..int.MaxValue] range) is regulated either explictly
      // by checked/unchecked keywords 
      // or implictly by /checked compiler directive, project settings et.c
      checked { // switch integer overflow check on 
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
