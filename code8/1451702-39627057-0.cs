    namespace Your.Relevant.Name
    {
      public static class SuccessHelperMethods
      {
        public static Success<TResult> BuildSuccess<TResult>(TResult result)
        {
          return new Success<TResult>(result);
        }
      }
    }
