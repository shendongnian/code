    public class Application
    {
        #region Public Constructors
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Application()
        {
            EmployeeApplications = new HashSet<EmployeeApplications>();
        }
    
        #endregion Public Constructors
    
        #region Public Properties
    
        public int ApplicationId { get; set; }
    
        public string Description { get; set; }
    
        //Navigation Property
        public virtual ICollection<EmployeeApplications> EmployeeApplications { get; set; }
    
        [Required]
        public string Name { get; set; }
    
        #endregion Public Properties
    }
    
    public class Employee
    {
        #region Public Constructors
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            EmployeeApplications = new HashSet<EmployeeApplications>();
        }
    
        #endregion Public Constructors
    
        #region Public Properties
    
        //Navigation Property
        public virtual ICollection<EmployeeApplications> EmployeeApplications { get; set; }
    
        public int EmployeeId { get; set; }
    
        [Required]
        public string FName { get; set; }
    
        [Required]
        public string LName { get; set; }
    
        public string Title { get; set; }
    
        #endregion Public Properties
    }
    
    public class EmployeeApplications
    {
        #region Public Properties
    
        public virtual Application Application { get; set; }
        public int ApplicationId { get; set; }
        public virtual Employee Employee { get; set; }
        public int EmployeeId { get; set; }
    
        #endregion Public Properties
    }
