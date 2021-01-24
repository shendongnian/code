    class KepElements
    {
        public double raan { get; set; }
        public double argperi { get; set; }
        public double meanan { get; set; }
        [UserFriendlyName("Mean Motion")]
        public double meanmotion { get; set; }
        public double eccentricity { get; set; }
        public double bstar { get; set; }
        public double epochYear { get; set; }
        public double inclination { get; set; }
        public double epochDay { get; set; }
    
        public override string ToString()
        {
            StringBuilder build = new StringBuilder();
            foreach (var property in typeof(KepElements).GetProperties())
            {
                build.AppendLine($"{property.GetUserFriendlyName()}: {property.GetValue(this)}");
            }
            return build.ToString();
        }
    }
    
    [AttributeUsage(AttributeTargets.Property)]
    public class UserFriendlyName : Attribute
    {
        public UserFriendlyName(string name)
        {
            Name = name;
        }
    
        public string Name { get; private set; }
    }
    
    public static class GetUserFriendlyNameExt
    {
        public static string GetUserFriendlyName(this PropertyInfo obj)
        {
            object[] attribs = obj.GetCustomAttributes(typeof(UserFriendlyName),false);
            if (attribs != null && attribs.Length > 0)
                return (attribs[0] as UserFriendlyName)?.Name;
            else
                return obj.Name;
        }
    }
