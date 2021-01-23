     public class Example {
       bool m_Bool;       // default value == false
       int m_Int;         // default value == 0
       double m_Double;   // default value == 0.0
       string m_Text      // default value == null;
       Example m_Example; // default value == null;
       public void Test() {
         bool boolValue;     // contains trash, must be initialized before using
         int intValue;       // contains trash, must be initialized before using
         double doubleValue; // contains trash, must be initialized before using 
         string textValue;   // reference to trash, must be initialized before using   
         Example example;    // reference to trash, must be initialized before using   
         ...
       } 
     }
