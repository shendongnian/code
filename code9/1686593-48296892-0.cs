    class Company
    {
        public int CompanyID { get; set; }
        public string Name { get; set; }
        public string DepartmentName { get; set; }
        public object Modify => new {
            CompanyID, Name, department = new { DepartmentName }
        };
    }
