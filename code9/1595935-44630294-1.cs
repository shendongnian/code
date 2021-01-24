    public class LookupsIndexViewModel
    {
        #region <Properties>
        private const string DEFAULT_PARTIAL_PATH = "~/Areas/Administration/Views/Lookups/Partials/ProductsPartial.cshtml";
        #endregion
        #region <Properties>
        public String PartialRelativePath { get; set; }
        public PartialViewModel PartialModel { get; set; }
        #endregion
        #region <Constructors>
        public LookupsIndexViewModel(string name)
        {
            Init(name);
        }
        #endregion
        #region <Methods>
        public void Init(string name)
        {
            PartialRelativePath = DEFAULT_PARTIAL_PATH;
            // TODO: Use a factory here
            if (!string.IsNullOrWhiteSpace(name))
                SetPartialProperties(name);
        }
		///<note>You could certainly replace this functionality with a Factory object</note>
        private void SetPartialProperties(string name)
        {
            string root = "~/Areas/Administration/Views/Lookups/Partials/";
            switch (name.ToLower())
            {
                case "andsoon":
                    PartialRelativePath = root + "AndSoOnPartial.cshtml";
                    PartialModel = new PartialViewModel();
                    break;
                case "areas":
                    PartialRelativePath = root + "AreasPartial.cshtml";
                    PartialModel = new PartialViewModel();
                    break;
                case "locations":
                    PartialRelativePath = root + "LocationsPartial.cshtml";
                    PartialModel = new PartialViewModel();
                    break;
                case "products":
                    PartialRelativePath = root + "ProductsPartial.cshtml";
                    PartialModel = new PartialViewModel();
                    break;
                case "someotherthing":
                    PartialRelativePath = root + "SomeOtherThingPartial.cshtml";
                    PartialModel = new PartialViewModel();
                    break;
                case "storageyards":
                    PartialRelativePath = root + "StorageYardsPartial.cshtml";
                    PartialModel = new PartialViewModel();
                    break;
                case "yetanotherthing":
                    PartialRelativePath = root + "YetAnotherThingPartial.cshtml";
                    PartialModel = new PartialViewModel();
                    break;
            }
        }
        #endregion
    }
	
	public class PartialViewModel
    {
		// Your awesome Strongly Typed View Model stuff goes here
    }
