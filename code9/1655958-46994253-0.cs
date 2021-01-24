    public class StudentEntity : IData  
    {  
      public static Dictionary<FieldInfo, string> ConversionInfo = new Dictionary<FieldInfo, string>
      {
        {fieldinfo1, "database column name 1"},
        {fieldinfo2, "database column name 2"},
        ...
      }
      ...
    }
