    public class LocalizedGridCoulmnAttribute : GridColumnAttribute
    {
        
        private Type _resourceType;
       
        /// <summary>
        /// The type of the Ressource file 
        /// </summary>
        public Type ResourceType
        {
            get
            {
                return this._resourceType;
            }
            set
            {
                if (this._resourceType != value)
                {
                    ResourceManager rm = new ResourceManager(value);
                    string someString = rm.GetString(LocalizedTitle);
                    this._resourceType = value ?? value;
                }
                if (ResourceType != null && LocalizedTitle != String.Empty)
                {
                    ResourceManager rm = new ResourceManager(ResourceType);
                    Title = rm.GetString(LocalizedTitle);
                }
            }
        }
        /// <summary>
        /// Overrides The Title Property of GridColumnAttribute
        /// Works with Ressourcefile
        /// </summary>
        public string LocalizedTitle
        {
            set {
                if (ResourceType != null && value != String.Empty)
                {
                    ResourceManager rm = new ResourceManager(ResourceType);
                    Title = rm.GetString(value);
                }
                else Title = value ?? value;
            }
            get { return Title; }
        }
    }
