    public class MyObject
        {
            public static Type GetMyObjectClassType()
            {
                return typeof(MyObject);
            }
            public static Type GetMyObjectInstanceType(MyObject someObject)
            {
                return someObject.GetType();
            }
    
        }
