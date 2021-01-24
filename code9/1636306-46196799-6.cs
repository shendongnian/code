    public partial class tblApplication    
        public int ID { get; set; }
        public string Name { get; set; }
        public int Level5ID { get; set; }
    
        public virtual tblLevel5s tblLevel5s { get; set; }
        public virtual ICollection<tblSystem> tblSystems { get; set; }
    }
    
    public partial class tblSystemApplication
    {
        public int ApplicationID { get; set; }
        public int SystemID { get; set; }
    
        public virtual tblApplication tblApplication { get; set; }
        public virtual tblSystem tblSystem { get; set; }
    }
    
    public partial class tblSystem
    {    
        public int ID { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<tblApplication> tblApplications { get; set; }
    }
