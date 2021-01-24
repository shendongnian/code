    class Position
    {
        public int Id {get; set;}
        // a Position has zero or more Employees:
        public virtual ICollection<Employee> Employees {get; set;}
        ...
    }
    class Employee
    {
        public int Id {get; set;}
        // every Employee belongs to exactly one Position using foreign key:
        public int PositionId {get; set;}
        public virtual Position Position {get; set;}
        ... 
    }
