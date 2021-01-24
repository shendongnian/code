    // provided by Brian Schroer
    [AttributeUsage(AttributeTargets.Property)]
    public class LocalizedDisplayNameAttribute : DisplayNameAttribute 
    {
        public LocalizedDisplayNameAttribute(string resourceKey)
        {
            ResourceKey = resourceKey;
        }
    
        private string ResourceKey { get; set; }
    
        public override string DisplayName
        {
            get
            {
                string displayName = FormLabels.ResourceManager.GetString(ResourceKey);
                return string.IsNullOrEmpty(displayName) ? string.Format("[[{0}]]", ResourceKey) : displayName;
            }
        }
    }
    
