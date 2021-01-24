    public static class ParameterExtensions
      {
        /// <summary>
        /// Extension method that converts any single dimensional object into Dapper's Dynamic Parameters
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="incoming"></param>
        /// <param name="allowNulls">Provide true to allow nulls to be mapped</param>
        /// <returns></returns>
        public static DynamicParameters ConvertToDynamicParameters<T>(this T incoming, bool allowNulls = false)
        {
          DynamicParameters dynamicParameters = new DynamicParameters();
          foreach (PropertyInfo property in incoming.GetType().GetProperties())
          {
            object value = GetPropValue(incoming, property.Name);
            if (value != null || allowNulls) dynamicParameters.Add($":{property.Name}", value);
          }
          return dynamicParameters;
        }
    
        private static object GetPropValue(object src, string propName)
        {
          return src.GetType().GetProperty(propName)?.GetValue(src, null);
        }
      }
