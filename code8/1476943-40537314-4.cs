    public Failable<T> DoFailableAction<T>(Func<T> f) {
      Failable<T> result;
      try {
        T fResult = f();
        result = new Success<T>(fResult);
      }
      catch (Exception ex) {
        result = new Failure<T>(ex);
        // Do logging, etc here...
      }
      return result;
    }
    public Failable DoFailableAction(Action f) {
      Failable result;
      try {
        f();
        result = new Success();
      }
      catch (Exception ex) {
        result = new Failure(ex);
        // Do logging, etc here...
      }
      return result;
    }
