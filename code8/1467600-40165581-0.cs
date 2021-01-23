    public class EnumUtils
    {
        public static string GetEnumDescription(object en)
        {
            Type type = en.GetType();
            MemberInfo[] memInfo = type.GetMember(en.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(EnumDescription), false);
                if (attrs != null && attrs.Length > 0)
                    return ((EnumDescription)attrs[0]).Text;
            }
            return en.ToString();
        }
        public static List<EnumObject> GetAllValuesFromEnum<T>()
        {
            List<EnumObject> AllValue = new List<EnumObject>();
            foreach (Enum enm in Enum.GetValues(typeof(T)))
            {
                AllValue.Add(new EnumObject(GetEnumDescription(enm), enm));
            }
            return AllValue;
        }
        public static Enum GetEnumValue<T>(string sEnumValue)
        {
            //List<EnumObject> allobject = GetAllValuesFromEnum<T>();
            foreach (Enum enm in Enum.GetValues(typeof(T)))
            {
                if (enm.ToString() == sEnumValue)
                    return enm;
            }
            return null;
        }
        public static Object GetEnumValueFromDescription<T>(string sEnumDescription) //where T: Enum 
        {
            List<EnumObject> allobject = GetAllValuesFromEnum<T>();
            foreach (EnumObject item in allobject)
            {
                if (item.EnumDisplay == sEnumDescription)
                    return item.EnumValue;
            }
            return default(T) as Enum;
        }
    }
    public class EnumObject
    {
        private string _EnumDisplay;
        private Enum _EnumValue;
        public EnumObject(string enumDisplay, Enum enumValue)
        {
            _EnumDisplay = enumDisplay;
            _EnumValue = enumValue;
        }
        public string EnumDisplay
        {
            get
            {
                return _EnumDisplay;
            }
            set
            {
                _EnumDisplay = value;
            }
        }
        public Enum EnumValue
        {
            get { return _EnumValue; }
            set { _EnumValue = value; }
        }
    }
    public class EnumDescription : Attribute
    {
        public string Text;
        public EnumDescription(string text)
        { Text = text; }
    }
