    public class MyEqualityComparer: IEqualityComparer<ClassA> {
      public bool Equals(ClassA x, ClassA y) {
        if (Object.ReferenceEquals(x, y))
          return true;  
        else if ((null == x) || (null == y))
          return false;
        // Your custom comparison here (...has to exclude few properties from ClassA)  
        ... 
      }
      public int GetHashCode(ClassA obj) {
        if (null == obj)
          return 0;
        // Your custom hash code based on the included properties 
        ...
      }
    }
