    public class ConvertStringToEnumExample {
       enum Colors { Red, Green, Blue, Yellow };
    
       public static void Main() {
    
          string colorString = "Yellow";
          Colors colorValue = (Colors) Enum.Parse(typeof(Colors), colorString); 
          
          // colorValue is now Colors.Yellow
          
        }
    }
