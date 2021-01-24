    class EmployeesData
    {
        public List<EmployeeSomethingA> EmployeeSomethingAs { get; set; }
        public List<EmployeeSomethingB> EmployeeSomethingBs { get; set; }
        public List<EmployeeSomethingC> EmployeeSomethingCs { get; set; }
        public void Where(Func<Employee, bool> predicate)
        {
            EmployeeSomethingAs = EmployeeSomethingAs.Where((Func<EmployeeSomethingA, bool>)predicate).ToList();
            EmployeeSomethingBs = EmployeeSomethingBs.Where((Func<EmployeeSomethingB, bool>)predicate).ToList();
            EmployeeSomethingCs = EmployeeSomethingCs.Where((Func<EmployeeSomethingC, bool>)predicate).ToList();
        }
    }
