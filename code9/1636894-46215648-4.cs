    public enum Grade {
       None, // <- zero option is often a good idea to include 
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
      public static bool IsCockpitPersonnel(this Grade grade) {
        return grade == Grade.Captain || 
               grade == Grade.SeniorFlightOfficer ||
               grade == Grade.SecondOfficer ||
               grade == Grade.JuniorFlightOfficer;
      } 
    }  
