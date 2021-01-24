    public class EmployeeProcedure
    {
        [Column("EmpId")]
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public double Salary { get; set; }
    }
