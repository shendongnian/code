    [Table("tblCompany")]
    public class CompanyProfile
    {
        [Key]
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyLogo { get; set; }
        public string TitlePic { get; set; }
        public string CopyText { get; set; }
        public string RegText { get; set; }
    }
    [Table("tblEmployee")]
    public class Employee
    {
        [Key]
        public int EmpID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int DepartmentId { get; set; }
        public string EmpNo { get; set; }
        public CompanyProfile { get; set; }
    }
    [Table("tblDepartment")]
    public class Department
    {
        [Key]
        public int DeptID { get; set; }
        public string DeptName { get; set; }
        public CompanyProfile { get; set; }
    }
