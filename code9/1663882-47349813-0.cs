    class Project
    {        
        public Guid Id { get; set; }
        // a project has zero or more Employees:
        public virtual ICollection<Employee> Employees {get;set;}
        // a project has zero or more Tools
        public virtual ICollectioin<Tool> Tools {get;set;}
    }
