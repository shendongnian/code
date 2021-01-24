     [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class RegionRegistrationAttribute: Attribute 
    {
        public RegionRegistrationAttribute()
        {
            
        }
        /// <summary>
        /// Name of region where view will be registred
        /// </summary>
        public String InjectionRegionName { get; set; }
        /// <summary>
        /// This is name of registartion in 
        /// </summary>
        public String RegistrationName { get; set; }
    }
