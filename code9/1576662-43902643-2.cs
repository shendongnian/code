    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    
    ...
    public static class DisplayAttributeHelper
    {
        public static string ReadDisplay(Enum target)
        {
            var attrs = target.GetType().GetMember(target.ToString())
                .First()
                .GetCustomAttributes(typeof(DisplayAttribute), false)
                .Cast<DisplayAttribute>();
    
            foreach (var attr in attrs)
                return attr.GetName();
    
            return target.ToString();
        }
    }
