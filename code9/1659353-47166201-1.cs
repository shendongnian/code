    public class EnumSafeXmlReader : XmlTextReader
    {
        private Assembly _callingAssembly;
        public EnumSafeXmlReader(Stream input) : base(input)
        {
            _callingAssembly = Assembly.GetCallingAssembly();
        }
        public override string ReadElementString()
        {
            string typename = this.Name;
            var val = base.ReadElementString();
            var possibleTypes = _callingAssembly.GetTypes().Where(t => t.Name == typename);
            Type enumType = possibleTypes.FirstOrDefault(t => t.IsEnum);
            if (enumType != null)
            {
                string[] allowedValues = Enum.GetNames(enumType);
                if (!allowedValues.Contains(val))
                {
                    val = Activator.CreateInstance(enumType).ToString();
                }
            }
            return val;
        }
    }
 
