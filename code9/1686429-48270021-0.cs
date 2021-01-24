    public partial class Employee
    {
        public Guid Id { get; set; }
        public Guid? CompanyId { get; set; } // <--
        public Company Company { get; set; }
    }
