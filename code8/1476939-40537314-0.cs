    public class Success<T> : Failable<T> {
      public Success(T value) {
        Value = value;
      }
  
      public T Value { get; set; }
    }
  
    public class Success : Failable {
    }
    public class Failure<T> : Failable<T> {
      public Failure(Exception value) {
        Value = value;
      }
  
      public Exception Value { get; set; }
    }
  
    public class Failure : Failable {
      public Failure(Exception value) {
        Value = value;
      }
  
      public Exception Value { get; set; }
    }
