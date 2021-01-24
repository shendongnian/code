       class Program {
          static void Main(String[] args) {
             // By using extension methods
             if ( "Hello world".ContainsAll(StringComparison.CurrentCultureIgnoreCase, "Hello", "world") ) 
                Console.WriteLine("Found everything by using an extension method!");
             else 
                Console.WriteLine("I didn't");
    
             // By using a single method
             if ( ContainsAll("Hello world", StringComparison.CurrentCultureIgnoreCase, "Hello", "world") )
                Console.WriteLine("Found everything by using an ad hoc procedure!");
             else 
                Console.WriteLine("I didn't");
    
          }
    
          private static Boolean ContainsAll(String str, StringComparison comparisonType, params String[] values) {
             return values.All(s => s.Equals(s, comparisonType));
          }    
       }
    
       // Extension method for your convinience
       internal static class Extensiones {
          public static Boolean ContainsAll(this String str, StringComparison comparisonType, params String[] values) {
             return values.All(s => s.Equals(s, comparisonType));
          }
       }
