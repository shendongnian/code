    /// <summary>
    /// includes all extensions for <see cref="Enum"/> operations.
    /// </summary>
    public static class EnumExtension
    {
        /// <summary>
        /// Retreives the Description as string. If there is no Description. You will get null.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum obj)
        {
            object[] attribArray = obj.GetType().GetField(obj.ToString()).GetCustomAttributes(false);
  
            if (attribArray.Length == 0)
                return null;
            if (attribArray[0] is DescriptionAttribute attrib)
            {
                return attrib.Description;
            }
            return null;
        }
    }
