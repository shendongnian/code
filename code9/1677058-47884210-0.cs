    public class DomainView
        {
            public int DomainID { get; set; }
            public string DomainCode { get; set; }
            public string DomainName { get; set; }
            public int TabOrder { get; set; }
            public string UserName { get; set; }
            public int CreatedBy { get; set; }
            public DateTime CreatedDate = DateTime.UtcNow;
            public int ModifiedBy { get; set; }
            public DateTime ModifiedDate = DateTime.UtcNow;
    
            public bool IsChecked { get; set; }
    
            public IEnumerable<DomainView> DomainViews { get; set; }
    
            public IEnumerable<ViewRoleModules> ModuleViews { get; set; }
        }
