    namespace Yoda.Frontend.Extensions
    {
      using System;
      using System.ComponentModel.DataAnnotations;
      using System.Globalization;
      using System.Linq;
      using System.Resources;
      public static class EnumExtensions
      {
        // This method can be made private if you don't use it elsewhere
        public static TAttribute GetEnumAttribute<TAttribute>(this Enum enumValue)
          where TAttribute : Attribute
        {
          var memberInfo = enumValue.GetType().GetMember(enumValue.ToString());
          return memberInfo[0].GetCustomAttributes(typeof(TAttribute), false)
                              .OfType<TAttribute>()
                              .FirstOrDefault();
        }
        public static string ToDescription(this Enum enumValue)
        {
          var displayAttribute = enumValue.GetEnumAttribute<DisplayAttribute>();
          return displayAttribute == null
            ? enumValue.ToString().Replace("_", " ")
            : new ResourceManager(displayAttribute.ResourceType)
                    .GetString(displayAttribute.Description, CultureInfo.CurrentUICulture);
        }
        public static string ToName(this Enum enumValue)
        {
          var displayAttribute = enumValue.GetEnumAttribute<DisplayAttribute>();
          return displayAttribute == null
            ? enumValue.ToString().Replace("_", " ")
            : new ResourceManager(displayAttribute.ResourceType)
                    .GetString(displayAttribute.Name, CultureInfo.CurrentUICulture);
        }
      }
      // Your other enum extension methods go here...
    }
