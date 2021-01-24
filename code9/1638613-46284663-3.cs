     public class BDKConfigsSection : ConfigurationSection
    {
        [ConfigurationProperty("BDK")]
        public BDKElementCollection BDKConfigs
        {
            get { return (BDKElementCollection) base["BDK"]; }
        }
    }
    [ConfigurationCollection(typeof(BDKElement))]
    public class BDKElementCollection : ConfigurationElementCollection
    {
        public BDKElement this[int index]
        {
            get { return (BDKElement)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                    BaseRemoveAt(index);
                BaseAdd(index, value);
            }
        }
        protected override ConfigurationElement CreateNewElement()
        {
            return new BDKElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((BDKElement)element).Name;
        }
        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMapAlternate; }
        }
        protected override string ElementName => "BDKItem";
    }
    public class BDKElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }
        [ConfigurationProperty("queryString", IsRequired = false)]
        public string Value
        {
            get { return (string)this["queryString"]; }
            set { this["queryString"] = value; }
        }
    }
