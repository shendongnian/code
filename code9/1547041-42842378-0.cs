     public class Application
        {
            #region Public Constructors
    
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
            public Application()
            {
                Employee = new HashSet<Employee>();
            }
    
            #endregion Public Constructors
    
            #region Public Properties
    
            public int ApplicationId { get; set; }
    
            public string Description { get; set; }
    
            //Navigation Property
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            public virtual ICollection<Employee> Employees { get; set; }
    
            [Required]
            public string Name { get; set; }
    
            #endregion Public Properties
        }
    
-----
        public class Employee
        {
            #region Public Constructors
    
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
            public Employee()
            {
                Applications = new HashSet<Application>();
            }
    
            #endregion Public Constructors
    
            #region Public Properties
    
            //Navigation Property
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            public virtual ICollection<Application> Applications { get; set; }
    
            public int EmployeeId { get; set; }
    
            [Required]
            public string FName { get; set; }
    
            [Required]
            public string LName { get; set; }
    
            public string Title { get; set; }
    
            #endregion Public Properties
        }
