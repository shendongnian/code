    public class EmployeeCollection : ObservableCollection<Employee>
    {
        public Employee Responsible { get; private set; }
        public EmployeeCollection():base(){}
        public EmployeeCollection(IEnumerable<Employee> employees) : base()
        {
            foreach (Employee e in employees)
            {
                if (e.IsResponsiblePerson)
                {
                    if(Responsible != null)
                        throw new ArgumentException("Multiple responsible employees aren't allowed", nameof(employees));
                    Responsible = e;
                }
                base.Add(e);
            }
        }
        public new void Add(Employee emp)
        {
            base.Add(emp);
            if (emp.IsResponsiblePerson)
            {
                MakeResponsible(emp);
            }
            emp.ResponsiblePersonChanged -= ResponsibleChanged;
            emp.ResponsiblePersonChanged += ResponsibleChanged;
        }
        private void ResponsibleChanged(Object sender, EventArgs e)
        {
            MakeResponsible(sender as Employee);
        }
        private void MakeResponsible(Employee employee)
        {
            if(!employee.IsResponsiblePerson)
                throw new ArgumentException("Employee is not responsible but should be", nameof(employee));
            
            if (Responsible != null && !Responsible.Equals(employee))
                Responsible.IsResponsiblePerson = false;
            Responsible = employee;
        }
    }
