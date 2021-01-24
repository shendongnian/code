    public class CabinCrue {
      ...
      public CabinCrue(Grade grade) {
        // Validation: Cabin Crue grade only
        // not Exception but ArgumentException: it's argument grade that's wrong
        if (!grade.IsCabinCrue()) 
          throw new ArgumentException("Cabin crue only", "grade");
        Grade = grade;
        ...
      } 
      public Grade Grade {
        get;
        private set;
      }
      ...
    } 
