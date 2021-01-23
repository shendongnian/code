    public class eCarsUsageAttribute : Attribute
        {
            public eCarsUsageAttribute() { }
            public eCarsUsageAttribute(bool allowInFApp = true)
            {
                AllowInFApp = allowInFApp;
            }
            public bool AllowInFApp { get; set; }
        }
        public enum eCars
        {
            [eCarsUsageAttribute]
            Toyota,
            [eCarsUsageAttribute]
            Honda,
            [eCarsUsageAttribute(false)]
            Hyundai,
            [eCarsUsageAttribute]
            BMW,
            [eCarsUsageAttribute]
            Acura
        };
        public static class EnumExtensions
        {
            public static bool AllowInFreeApp(this eCars value)
            {
                lock (_usageValues)
                {
                    //reflection is somewhat expensive so I'd recommend using a local store to keep the attributes that you have already looked up
                    if (!_usageValues.ContainsKey(value))
                    {
                        // Get the type
                        Type type = value.GetType();
    
                        // Get fieldinfo for this type
                        System.Reflection.FieldInfo fieldInfo = type.GetField(value.ToString());
    
                        // Get the stringvalue attributes
                        eCarsUsageAttribute[] attribs = fieldInfo.GetCustomAttributes(typeof(eCarsUsageAttribute), false) as eCarsUsageAttribute[];
    
                        var attr = attribs.FirstOrDefault();
                        if (attr != null)
                            _usageValues[value] = attr.AllowInFApp;
                        else
                            _usageValues[value] = false;//Depends on what you want the default behavior to be
    
                    }
                    return _usageValues[value];
                }
            }
            private static Dictionary<eCars, bool> _usageValues = new Dictionary<eCars, bool>();
        }
