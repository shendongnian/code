    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? DepartmentId { get; set; }
        public Department ParentDepartment { get; set; }
        public virtual ICollection<Department> ChildDepartments { get; set; }
    }
