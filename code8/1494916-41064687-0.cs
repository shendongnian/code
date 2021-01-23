    processClasses(List<object> myClasses)
    {
      foreach(A obj in myClasses.OfType<A>()) {
        doSomeWork(A.GetType(), new OtherWork<A>());
      }
      foreach(B obj in myClasses.OfType<B>()) {
        doSomeWork(B.GetType(), new OtherWork<B>());
      }
      foreach(C obj in myClasses.OfType<C>()) {
        doSomeWork(C.GetType(), new OtherWork<C>());
      }
    }
