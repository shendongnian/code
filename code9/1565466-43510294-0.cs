    public class AClass()
    {
       public static float staticField;
       public float field;
       public AClass()
       {
           staticField = 5;
           field = 6;
       }
       static AClass()
       {
           staticField = 7;
       }
    }
    public int Main()
    {
         float initially = AClass.staticField; // initially this staticField is 7.
         AClass aclass = new AClass(); // instantiating AClass
         float localfield = aclass.field; // this field does not affect anyone. It is 6
         float newStaticField = AClass.staticField; // Due to previous instantiation, the value is now 5.
         
    }
