    public static class CsvSerializer
    {
      public static bool Serialize<T>(string path, IList<T> data, string delimiter = ";")
      {
        var csvBuilder = new StringBuilder();
        var dataType = typeof(T);
        var properties = dataType.GetProperties()
                                 .Where(prop => prop.GetCustomAttribute(typeof(CsvSerialize)) == null);
        //write header
        foreach (var property in properties)
        {
          csvBuilder.Append(property.Name);
          if (property != properties.Last())
          {
            csvBuilder.Append(delimiter);
          }
        }
        csvBuilder.Append("\n");
       //data
       foreach (var dataElement in data)
       {
         foreach (var property in properties)
         {
           csvBuilder.Append(property.GetValue(dataElement));
           if (property != properties.Last())
           {
             csvBuilder.Append(delimiter);
           }
         }
         csvBuilder.Append("\n");
       }
       File.WriteAllText(path, csvBuilder.ToString());
       return true;
     }
    }
    public class CsvSerialize : Attribute
    {
    }
