        public int Id { get; set; }
        //(...)
        [InverseProperty("ConfigurationPackage")]
        public List<ConfigurationClass> Configurations { get; set; }
    }
    
    public class ConfigurationClass
    {
        public int Id { get; set; }
        [ForeignKey("ConfigurationPackage")]
        public int ConfigurationPackageId { get; set; }
        public ConfigurationPackage ConfigurationPackage { get; set; }
        [InverseProperty("ConfigurationClass")]
        public List<ConfigurationPropertyBase> ConfigurationProperties { get; set; }
    }
    
    public abstract class ConfigurationPropertyBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //(no navigation propeties here)
        [ForeignKey("ConfigurationClass")]
        public int ConfigurationClassId { get; set; }
        public ConfigurationClass ConfigurationClass { get; set; }
    }
