    public class ConvertEnumToStringExample {
       enum Colors { Red, Green, Blue, Yellow };
    
       public static void Main() {
    
          Console.WriteLine("The 4th value of the Colors Enum is {0}", Enum.GetName(typeof(Colors), 3));
          Console.WriteLine("The 4th value of the Colors Enum is {0}", Enum.GetName(typeof(Colors), Colors.Yellow));
        }
    }
