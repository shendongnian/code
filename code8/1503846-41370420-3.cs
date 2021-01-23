        public class FiltersSettings : ConfigurationSection
        {
          public static FiltersSettings Settings
           {
              get {
                 var section = ConfigurationManager.GetSection("filters")
                          as FiltersSettings;
                 return section ?? new FiltersSettings();                
                  }
            }
         [ConfigurationProperty("", IsDefaultCollection = true)]
         public FilterActionCollection Filters
           {
            get { return base[_filtersProperty] as FilterActionCollection; }
            set { base[_filtersProperty] = value; }
           }
        private readonly ConfigurationProperty _filtersProperty = 
        new ConfigurationProperty(
            null, typeof (FilterActionCollection), null, 
            ConfigurationPropertyOptions.IsDefaultCollection);
      }
