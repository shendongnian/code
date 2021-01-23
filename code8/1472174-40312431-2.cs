    public class IncludeInApiExplorerAttribute : Attribute
    {
        private readonly bool value;
        public IncludeInApiExplorerAttribute(string IsInAPI=null)
        {
            if (!string.IsNullOrEmpty(IsInAPI))
            {
                value = Convert.ToBoolean(ConfigurationManager.AppSettings[IsInAPI]); //Reads the app config value
            }
            else
            {
                value = true;
            }
        }
        public bool Value { get { return value; } }
    }
