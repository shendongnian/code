       [Serializable]
        public partial class JobTitle : IJobTitle
        {
    
            public JobTitle()
            {
                CommonConstructor();
            }
            private void CommonConstructor()
            {
                //this.MyEmployees = new List<Employee>();
                //this.MyJobTitleToEmployeeMatchLinks = new List<EmployeeToJobTitleMatchLink>();
                this.MyJobTitleToEmployeeMatchLinks = new EmployeeToJobTitleMatchLinkCollection();
            }
    
            public Guid? JobTitleUUID { get; set; }
            //public int? JobTitleKey { get; set; }
    
    
            //public byte[] TheVersionProperty { get; set; }
    
    
            public string JobTitleName { get; set; }
            public DateTime CreateDate { get; set; }
    
            //public ICollection<Employee> MyEmployees { get; set; }
            //public ICollection<IEmployeeToJobTitleMatchLink> MyJobTitleToEmployeeMatchLinks { get; set; }
            //public ICollection<EmployeeToJobTitleMatchLink> MyJobTitleToEmployeeMatchLinks { get; set; }
            public IEmployeeToJobTitleMatchLinkCollection MyJobTitleToEmployeeMatchLinks { get; set; }
    
    
            public void AddEmployeeLink(EmployeeToJobTitleMatchLink link)
            {
                link.TheJobTitle = this;
                if (!this.MyJobTitleToEmployeeMatchLinks.Contains(link))
                {
                    this.MyJobTitleToEmployeeMatchLinks.Add(link);
                }
    
                if (!link.TheEmployee.MyEmployeeToJobTitleMatchLinks.Contains(link))
                {
                    link.TheEmployee.MyEmployeeToJobTitleMatchLinks.Add(link);
                }
    
            }
    
            public void RemoveEmployeeLink(EmployeeToJobTitleMatchLink link)
            {
                link.TheJobTitle = this;
                if (this.MyJobTitleToEmployeeMatchLinks.Contains(link))
                {
                    this.MyJobTitleToEmployeeMatchLinks.Remove(link);
                }
    
                if (link.TheEmployee.MyEmployeeToJobTitleMatchLinks.Contains(link))
                {
                    link.TheEmployee.MyEmployeeToJobTitleMatchLinks.Remove(link);
                }
    
            }
    
        }
    }
