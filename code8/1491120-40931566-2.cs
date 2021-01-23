     public abstract class WeirdModel {
       // It's not me who implement this readonly property 
       protected abstract String Something {get;}
     }
     public class EerieModel {
       // write-only banned property  
       [Obsolete("Do not call obsolete properties!", true)]
       public string DoNotCallMe(set {...})
     }
     public class PrivateModel {
       // That's for me only
       private string PersonalInfo {get; set;} 
     } 
     public class StaticModel {
       // One property for all instances
       public static string CommonInfo {get; set;} 
     } 
