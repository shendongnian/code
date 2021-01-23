    [Flags]
        enum Colors
        {
            [Description("None")]
            None=0,
            [Description("Red")]
            Red= 1<<0,
            [Description("Burnt Yellow")]
            Yellow = 1<<1,
            [Description("Blue")]
            Blue= 1<<2,
            [Description("Green")]
            Green=1<<3,
            [Description("Red | Yellow| Blue | Green")]
            All = 99
        }
    // Now create helper class and function to get enum description for associated value.
    using System;
    using System.ComponentModel;
    using System.Reflection;
   
    public static class EnumHelper
    {
        /// <summary>
        /// Retrieve the description on the enum, e.g.
        /// [Description("Bright Pink")]
        /// BrightPink = 2,
        /// Then when you pass in the enum, it will retrieve the description
        /// </summary>
        /// <param name="en">The Enumeration</param>
        /// <returns>A string representing the friendly name</returns>
        public static string GetDescription(Enum en)
        {
            Type type = en.GetType();
            MemberInfo[] memInfo = type.GetMember(en.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            return en.ToString();
        }
    }
   
    //Now use this function to get attribute for your enum value.
    Console.WriteLine(EnumHelper.GetDescription(Colors.All));
 
