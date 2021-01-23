        public class SettingDataValue
        {
            public Guid guid { get; set; }
            public string SettingName { get; set; }
            public string SettingValue { get; set; }
            public string SettingType { get; set; }
        }
        public static dynamic getSettingFromDB(string name)
        {
            SettingDataValue s = new SettingDataValue();
            using (IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["NetworkCafeConnectionString"].ConnectionString))
            {
                s = _db.Query<SettingDataValue>("Select guid, SettingName, SettingValue ,SettingType from SiteSettings where SettingName = '" + name + "'").FirstOrDefault();
            }
            Type type = Type.GetType(s.SettingType);
            var converter = TypeDescriptor.GetConverter(type);
            return converter.ConvertFrom(s.SettingValue);
        }
