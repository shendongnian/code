    // CS0236.cs
    public class MyClass
    {
       public int i = 5;
       public int j = i;  // CS0236
       public int k;      // initialize in constructor
    
       MyClass()
       {
          k = i;
       }
    
       public static void Main()
       {
       }
    }
