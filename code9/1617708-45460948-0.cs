    public class Employee
        {
          public int Id { get; set; }
          public string Name { get; set; }
          public string Surname { get; set; }
        
          [Display(Name = "Phone Number")]
          public int PhoneNumber { get; set; }
        
        public virtual ICollection<Commission> Commissions{ get; set; }
        public virtual ICollection<Position> Positions{ get; set; }
        }
        public class Commission
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        public virtual ICollection<Employee> Employees{ get; set; }
        public virtual ICollection<Position> Positions{ get; set; }
        }
        public class Position
        {
            public int Id { get; set;}
            public string Name { get; set; }
        public virtual ICollection<Employee> Employees{ get; set; }
        public virtual ICollection<Commission> Commissions{ get; set; }
        }
