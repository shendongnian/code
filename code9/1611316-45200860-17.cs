    {
        [Serializable]
        public partial class Employee 
        {
    
            public Employee()
            {
                CommonConstructor();
            }
            private void CommonConstructor()
            {
                this.MyEmployeeToJobTitleMatchLinks = new EmployeeToJobTitleMatchLinkCollection();
            }
    
    
    
            //EF Tweaks
            public Guid ParentDepartmentUUID { get; set; }
    
    
            public Guid? EmployeeUUID { get; set; }
    
            public byte[] TheVersionProperty { get; set; }
    
            //public int? EmployeeKey { get; set; }
    
    
    
    //        public IDepartment ParentDepartment { get; set; }
    
            public string SSN { get; set; }
            public string LastName { get; set; }
            public string FirstName { get; set; }
            public DateTime CreateDate { get; set; }
            public DateTime HireDate { get; set; }
            //
    
    
    
            public EmployeeToJobTitleMatchLinkCollection MyEmployeeToJobTitleMatchLinks { get; set; }
    
    
    
    
            public void AddJobTitleLink(EmployeeToJobTitleMatchLink link)
            {
                link.TheEmployee = this;
                if (!this.MyEmployeeToJobTitleMatchLinks.Contains(link))
                {
                    this.MyEmployeeToJobTitleMatchLinks.Add(link);
                }
    
                if (!link.TheJobTitle.MyJobTitleToEmployeeMatchLinks.Contains(link))
                {
                    link.TheJobTitle.MyJobTitleToEmployeeMatchLinks.Add(link);
                }
            }
    
            public void RemoveJobTitleLink(EmployeeToJobTitleMatchLink link)
            {
                link.TheEmployee = this;
                if (this.MyEmployeeToJobTitleMatchLinks.Contains(link))
                {
                    this.MyEmployeeToJobTitleMatchLinks.Remove(link);
                }
    
                if (link.TheJobTitle.MyJobTitleToEmployeeMatchLinks.Contains(link))
                {
                    link.TheJobTitle.MyJobTitleToEmployeeMatchLinks.Remove(link);
                }
            }
    
    
    
    
    
    
    
    
    
    
    
            //public ICollection<IParkingAreaDeprecated> MyParkingAreas { get; set; }
            //public ICollection<ParkingArea> MyParkingAreas { get; set; }
            public IParkingAreaCollection MyParkingAreas { get; set; }
            
    
    
    
    
            //public void AddParkingArea(IParkingAreaDeprecated pa)
            public void AddParkingArea(ParkingArea pa)
            {
                //pa.MyEmployees.Add(this);
                if (!pa.MyEmployees.Contains(this))
                {
                    //pa.AddEmployee(this);//Causes overflow situation
                    pa.MyEmployees.Add(this);
                }
                if (!this.MyParkingAreas.Contains(pa))
                {
                    this.MyParkingAreas.Add(pa);
                }
            }
    
            //public void RemoveParkingArea(IParkingAreaDeprecated pa)
            public void RemoveParkingArea(ParkingArea pa)
            {
                if (pa.MyEmployees.Contains(this))
                {
                    pa.MyEmployees.Remove(this);
                }
                if (this.MyParkingAreas.Contains(pa))
                {
                    this.MyParkingAreas.Remove(pa);
                }
            }
    
    
            public override string ToString()
            {
               return string.Format("{0}:{1},{2}", this.SSN , this.LastName , this.FirstName );
            }
    
    
    
        }
    
    
    
    
    }
