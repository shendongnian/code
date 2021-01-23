    public class ConnectionGroupConfigurationSection : ConfigurationSection
    {
        public const string NodeName = "connectionGroup";
        [ConfigurationProperty("", IsDefaultCollection=true)]
        public ConnectionGroupConfigurationElementCollection ConnectionGroup
        {
            get { return (ConnectionGroupConfigurationElementCollection)this[""]; }
        }
    }
    public class ConnectionGroupConfigurationElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ConnectionElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return (element as ConnectionElement).Id;
        }
        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }
        protected override string ElementName
        {
            get { return "connection"; }
        }
    }
    
    public class ConnectionElement : ConfigurationElement
    {
        [ConfigurationProperty("url", IsRequired=true, IsKey=true)]
        public string Url { get { return (string)this["url"]; } }
        [ConfigurationProperty("database", DefaultValue = "mydb", IsRequired = false)]
        public string Database { get { return (string)this["database"]; } set { this["database"] = value; } }
    }
