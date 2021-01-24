    public partial class Employee
    {
        ...
        [InverseProperty("EmployeeIssuedToId")]
        public virtual Certification Certification { get; set; }
    }
