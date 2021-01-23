    class CarSection : ConfigurationSection
    {
        [ConfigurationProperty("", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(CarCollection),
            AddItemName = "add",
            ClearItemsName = "clear",
            RemoveItemName = "remove")]
        public CarCollection Cars
        {
            get
            {
    
                return (CarCollection)base[property];
            }
        }
    
        static ConfigurationProperty  property = new ConfigurationProperty(null, typeof(CarCollection), null, ConfigurationPropertyOptions.IsDefaultCollection);
        protected override ConfigurationPropertyCollection Properties
        {
            get
            {
                var configurationPropertyCollection = new ConfigurationPropertyCollection();
                configurationPropertyCollection.Add(property);
                return configurationPropertyCollection;
            }
        }
    }
    
