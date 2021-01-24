    public class clsEmployees : IEnumerable<clsEmployee>
    {
        private SortedList<int, clsEmployee> EmployeeList;
    
        public clsEmployees()
        {
            EmployeeList = new SortedList<int, clsEmployee>();
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public IEnumerator<clsEmployee> GetEnumerator()
        {
            return EmployeeList.Values.GetEnumerator();
        }
    
        public void Add(clsEmployee NewEmployee)
        {
            EmployeeList.Add(NewEmployee.Number, NewEmployee);
        }
    
        public clsEmployee Item(int Index)
        {
            return EmployeeList[Index];
        }
    }
