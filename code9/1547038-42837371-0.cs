        public class EmployeeApplications
            {
                public int EmployeeId { get; set; }
                public int ApplicationId { get; set; }
                public virtual Employee Employee { get; set; }
                public virtual Application Application { get; set; }
            }
    
        public class Application
            {
                public int ApplicationId { get; set; }
        
                [Required]
                public string Name { get; set; }
        
                public string Description { get; set; }
        
                //Navigation Property
                public  virtual ICollection<EmployeeApplications> EmployeeApplications { get; set; }
            }
    
     public class Application
        {
            public int ApplicationId { get; set; }
    
            [Required]
            public string Name { get; set; }
    
            public string Description { get; set; }
    
            //Navigation Property
            public virtual ICollection<EmployeeApplications> EmployeeApplications { get; set; }
        }
