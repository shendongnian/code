    public class DomainElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }
    
        [ConfigurationProperty("source", IsRequired = true, DefaultValue = "170")]
        public string Source
        {
            get { return (string)this["source"]; }
            set { this["source"] = value; }
        }
    }
    
    [ConfigurationCollection(typeof(DomainElement))]
    public class DomainCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new DomainElement();
        }
    
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((DomainElement)element).Name;
        }
    }
    
    public class DomainSection : ConfigurationSection
    {
        [ConfigurationProperty("domainIDs", IsDefaultCollection = true)]
        public virtual DomainCollection domainIDs
        {
            get { return (DomainCollection)this["domainIDs"]; }
        }
    }
