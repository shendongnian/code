    public enum Grade {
       None, // <- zero option is often a good idea to iтclude 
       Captain,
       SeniorFlightOfficer,
       SecondOfficer,
       JuniorFlightOfficer,
       Steward,
       Purser };
    public static class GradeExtensions { 
      public static bool IsCabinCrue(this Grade grade) {
        return grade == Grade.Steward || grade == Grade.Purser;
      }
    }  
