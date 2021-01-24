    public class CabinCrue {
      ...
      public CabinCrue(Grade grade) {
        // Validation: Cabin Crue grade only
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
