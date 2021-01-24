        public static void Main()
        {
            var employeeList = new List<Employee>()
            {
                new Employee(){ ID= 1,Name= "A"},
                new Employee() { ID= 2,Name= "B"},
                new Employee() { ID= 3,Name= "AA"},
                new Employee() { ID= 4,Name= "C"},
                new Employee() { ID= 5,Name= "CD"},
                new Employee() { ID= 100,Name= "Z"}
            };
            var orderByArray = new int[] { 2, 3, 1, 100, 5, 4 };
            var sortPos = orderByArray.Select((i, index) => new { ID = i, SortPos = index });
            var joinedList = employeeList.Join(sortPos, e => e.ID, sp => sp.ID, (e, sp) => new { ID = e.ID, Name = e.Name, SortPos = sp.SortPos });
            var sortedEmployees = joinedList.OrderBy(e => e.SortPos).Select(e => new Employee { ID = e.ID, Name = e.Name });
        }
